using AutoMapper;
using eAutobusModel;
using eAutobusModel.Requests;
using Microsoft.EntityFrameworkCore;
using eAutobus.Database;
using eAutobus.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace eAutobus.Services
{
    public class KartaService : IKartaService   
    {
        private readonly eAutobusi _context;
        private readonly IMapper _mapper;
        private readonly IKupacService _kupac;
        private readonly IKartaKupacService _kartaKupac;
        private readonly IPlatiOnlineService _onlinePlacanje;
        public KartaService(eAutobusi context, IMapper mapper, IKupacService kupac, IKartaKupacService kartaKupac, IPlatiOnlineService onlinePlacanje)
        {
            _context = context;
            _mapper = mapper;
            _kupac = kupac;
            _kartaKupac = kartaKupac;
            _onlinePlacanje = onlinePlacanje;
        }
        public async Task<KartaModel> Delete(int id)
        {
            var entity =await _context.Karta.FirstOrDefaultAsync(k=>k.KartaID==id);
            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
            return _mapper.Map<KartaModel>(entity);
        }

        public async Task<List<KartaModel>> Get(KartaGetRequest request)
        {
            var query = _context.Karta.Include(v => v.VrstaKarte)
                                    .Include(k=>k.KupacList)
                                    .Include(t => t.TipKarte)
                                    .Include(p=>p.PlaceneKarte)
                                    .Include("KupacList.Kupac")
                                    .Include(o=>o.Odrediste)
                                    .Include(p=>p.Polaziste)
                                    .Where(k=>k.IsDeleted==false && k.NacinPlacanja== "Preuzećem")
                                    .AsQueryable();
            var list = await query.ToListAsync();
            var listM = new List<KartaModel>();
            _mapper.Map(list, listM);
            for (int i = 0; i < list.Count(); i++)
            {
                listM[i].VrstaKarte = list[i].VrstaKarte.Naziv;
                listM[i].TipKarte = list[i].TipKarte.Naziv;
                listM[i].Relacija = list[i].Polaziste.NazivLokacijeStanice + " - " + list[i].Odrediste.NazivLokacijeStanice;
                foreach (var item in list[i].KupacList)
                {
                    listM[i].DatumVadjenjaKarte = item.DatumVadjenjaKarte;
                    listM[i].DatumVazenjaKarte = item.DatumVazenjaKarte;
                    listM[i].ImePrezimeKupca = item.Kupac.Ime + " " + item.Kupac.Prezime;
                   
                }
                foreach (var item in list[i].PlaceneKarte)
                {
                        listM[i].JeLiPlacena = item.JeLiPlacena;
                }

            }
            return listM;

        }

        public async Task<KartaModel> GetById(int id)
        {
            var entity = await _context.Karta.Include(k=>k.PlaceneKarte).Include(k=>k.KupacList).FirstOrDefaultAsync(x=>x.KartaID==id);
            var entityK = new KartaModel();
            _mapper.Map(entity, entityK);
            foreach (var item in entity.KupacList)
            {
                if (item.KartaID == id)
                {
                    entityK.DatumVadjenjaKarte = item.DatumVadjenjaKarte;
                    entityK.DatumVazenjaKarte = item.DatumVazenjaKarte;
                    entityK.KupacID = item.KupacID;
                }
                
            }
            return entityK;
          
        }

        public async Task<KartaModel> Insert(KartaUpsertRequest request)
        {
            var kupac = new KupacInsertRequest()
            {
                Ime = request.Ime,
                Prezime = request.Prezime,
                AdresaStanovanja = request.AdresaStanovanja,
                BrojTelefona = request.BrojTelefona,
                Email = request.Email ?? " ",
                KorisnickoIme = request.KorisnickoIme ?? " ",
            };
            var entity = _mapper.Map<Karta>(request);
            bool postoji = await ProvjeriKartu(kupac);
                if (!postoji)
                {
                    _context.Karta.Add(entity);
                    await _context.SaveChangesAsync();
                    KupacModel newKupac = new KupacModel();
                    Kupac pronadjeni = await _kupac.PronadjiKupca(kupac);
                    if (pronadjeni == null)
                    {
                        kupac.Password = "";
                        kupac.PotvrdaPassworda = "";
                        newKupac = await _kupac.Insert(kupac);

                    }
                    else
                    {
                        newKupac.KupacID = pronadjeni.KupacID;
                    }
                    var kupacKarta = new KartaKupacUpsertRequest()
                    {
                        Aktivna = true,
                        DatumVadjenjaKarte = request.DatumVadjenjaKarte,
                        DatumVazenjaKarte = request.DatumVazenjaKarte,
                        KartaID = entity.KartaID,
                        KupacID = newKupac.KupacID,
                        Pravac = request.Pravac,
                        PravacS = request.PravacS,
                    };

                    KartaKupacModel osobineKarte = _kartaKupac.Insert(kupacKarta);
                    request.KupacID = newKupac.KupacID;
                    request.KartaID = entity.KartaID;
                    if (request.NacinPlacanja == "Online")
                    {
                        var onlineplati = new PlatiKartuUpsertRequest()
                        {
                            KartaID = request.KartaID,
                            KupacID = request.KupacID,
                            Cijena = request.Cijena,
                            DatumVadjenjaKarte = request.DatumVadjenjaKarte,
                            DatumVazenjaKarte = request.DatumVazenjaKarte,
                            JeLiPlacena = true,
                        };
                        await _onlinePlacanje.Insert(onlineplati);
                }
                return _mapper.Map<KartaModel>(request);
                }
            return null;  
        }

        private async Task<bool> ProvjeriKartu(KupacInsertRequest trazeni)
        {
            var pronadjiKupca = await _kupac.PronadjiKupca(trazeni);
            if (pronadjiKupca!=null && pronadjiKupca.KartaList!=null)
            {
                foreach (var item in pronadjiKupca.KartaList)
                {
                    if (DateTime.Parse(DateTime.Now.ToShortDateString())>DateTime.Parse(item.DatumVazenjaKarte.ToShortDateString()))
                    {
                        item.Aktivna = false;
                    }
                }
            }
            return false;
        }

        public async Task<KartaModel> Update(KartaUpsertRequest request, int id)
        {
            var update = await _context.Karta.Include(k=>k.PlaceneKarte).FirstOrDefaultAsync(k=>k.KartaID==id);
            _mapper.Map(request, update);
            await _context.SaveChangesAsync();
            return _mapper.Map<KartaModel>(update);
        }
        public async Task<KartaModel> UplatiKartu(int id,PlatiKartuUpsertRequest request)
        {
            var platiK = await _context.Karta.Include(k => k.PlaceneKarte).Include(k => k.KupacList).Where(k=>k.NacinPlacanja == "Preuzećem").FirstOrDefaultAsync(k => k.KartaID == id);
            
            var response = _onlinePlacanje.Insert(request);
            return _mapper.Map<KartaModel>(platiK);
        }
    }
}
