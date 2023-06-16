using AutoMapper;
using eAutobusModel;
using Microsoft.EntityFrameworkCore;
using eAutobus.Database;
using eAutobus.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using eAutobus.ML;

namespace eAutobus.Services
{
    public class PreporukeService : IPreporukeService
    {
        private readonly Database.eAutobusi _context;
        private readonly IMapper _mapper;

        public PreporukeService(Database.eAutobusi context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        Dictionary<int, List<Recenzija>> linije = new Dictionary<int, List<Recenzija>>();

        public async Task<List<RasporedVoznjeModel>> Get(int RasporedLinijaID)
        {
            var linija = await _context.RasporedVoznje.Include(r => r.Recenzija).FirstOrDefaultAsync(r => r.RasporedVoznjeID == RasporedLinijaID);
            int ocjena = 0;
            foreach (var o in linija.Recenzija)
            {
                ocjena += o.Ocjena;
            }

            if(linija.Recenzija.Count() > 0)
                linija.FinalOcjena = ocjena / linija.Recenzija.Count();

            return _mapper.Map<List<RasporedVoznjeModel>>(linija);
        }



        public async Task<List<RasporedVoznjeModel>> Recommend(int id)
        {
            var linijeA = await _context.RasporedVoznje
                .Include(o => o.Odrediste)
                .Include(d => d.Polaziste)
                .Include(r => r.Recenzija)
                .Include(v => v.Vozac)
                .Include(k => k.Kondukter)
                .Include("Vozac.Korisnik").Where(r => r.RasporedVoznjeID != id && r.IsDeleted == false).ToListAsync();

            decimal ocjena = 0;
            List<Recenzija> ocjene;
            foreach (var item in linijeA)
            {
                ocjene = _context.Recenzija.
                    Include(x => x.RasporedVoznje)
                    .Include(x => x.Kupac)
                    .Include("RasporedVoznje.Polaziste")
                    .Include("RasporedVoznje.Odrediste")
                    .Where(o => o.RasporedVoznjeID == item.RasporedVoznjeID).OrderBy(x => x.KupacID).ToList();
                if (ocjene.Count > 0)
                {
                    linije.Add(item.RasporedVoznjeID, ocjene);
                }
            }
            var recenzijeT = _context.Recenzija
                .Include(x => x.RasporedVoznje)
                .Include(x => x.Kupac)
                .Include("RasporedVoznje.Polaziste")
                .Include("RasporedVoznje.Odrediste")
                .Where(x => x.RasporedVoznjeID == id).OrderBy(x => x.KupacID);
            var zajednickeR1 = new List<Recenzija>();
            var zajednickeR2 = new List<Recenzija>();

            var preporuceneLinijeIds = new List<int>();
            foreach (var x in linije)
            {
                foreach (var y in recenzijeT)
                {
                    if (x.Value.Where(x => x.KupacID == y.KupacID).Count() > 0)
                    {
                        zajednickeR1.Add(y);
                        zajednickeR2.Add(x.Value.Where(x => x.KupacID == y.KupacID).First());
                    }
                }
                double slicnost = GetSlicnost(zajednickeR1, zajednickeR2);
                if (slicnost > 0.5)
                {
                    var ocjenjeneLinije = linije.Select(e => e.Value).SelectMany(e => e).Where(e => e.Ocjena >= 3).Select(e => e.RasporedVoznjeID).Where(e => !preporuceneLinijeIds.Contains(e)).ToList();
                    ocjenjeneLinije.ForEach(e =>
                    {
                        if (!preporuceneLinijeIds.Contains(e))
                            preporuceneLinijeIds.Add(e);

                    });
                }
                zajednickeR1.Clear();
                zajednickeR2.Clear();
            }
            var preporuka = _context.Set<RasporedVoznje>().Include(o => o.Odrediste).Include(a=>a.Autobus)
                .Include(d => d.Polaziste)
                .Include(r => r.Recenzija)
                .Include(v => v.Vozac)
                .Include(k => k.Kondukter)
                .Include("Vozac.Korisnik").Where(x=>preporuceneLinijeIds.Contains(x.RasporedVoznjeID)).ToList();
            var preporukaM = new List<RasporedVoznjeModel>();
            _mapper.Map(preporuka, preporukaM);

            for (int i = 0; i < preporuka.Count; i++)
            {
                preporukaM[i].Odlazak = preporuka[i].Odrediste.NazivLokacijeStanice;
                preporukaM[i].Polazak = preporuka[i].Polaziste.NazivLokacijeStanice;
                preporukaM[i].BrojAutobusa = preporuka[i].Autobus.BrojAutobusa;
                preporukaM[i].NazivLinije = preporuka[i].Polaziste.NazivLokacijeStanice + "-" + preporuka[i].Odrediste.NazivLokacijeStanice;
                preporukaM[i].Datum = DateTime.Parse(preporuka[i].Datum.Date.ToString());
                preporukaM[i].VrijemeDolaska = DateTime.Parse(preporuka[i].VrijemeDolaska.ToString("G"));
                preporukaM[i].VrijemePolaska = DateTime.Parse(preporuka[i].VrijemePolaska.ToString("G"));
            }
            return _mapper.Map<List<RasporedVoznjeModel>>(preporukaM);
        }

        private double GetSlicnost(List<Recenzija> zajednickeR1, List<Recenzija> zajednickeR2)
        {
            if (zajednickeR1.Count != zajednickeR2.Count)
                return 0;

            double brojnik = 0, nazivnik1 = 0, nazivnik2 = 0;
            for (int i = 0; i < zajednickeR1.Count; i++)
            {
                brojnik = zajednickeR1[i].Ocjena * zajednickeR2[i].Ocjena;
                nazivnik1 = zajednickeR1[i].Ocjena * zajednickeR1[i].Ocjena;
                nazivnik2 = zajednickeR2[i].Ocjena * zajednickeR2[i].Ocjena;
            }
            nazivnik1 = Math.Sqrt(nazivnik1);
            nazivnik2 = Math.Sqrt(nazivnik2);
            double nazivnik = nazivnik1 * nazivnik2;
            if (nazivnik == 0)
                return 0;
            return brojnik / nazivnik;
        }
    } 
}
