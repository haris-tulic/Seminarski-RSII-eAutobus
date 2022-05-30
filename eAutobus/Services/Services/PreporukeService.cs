using AutoMapper;
using eAutobusModel;
using Microsoft.EntityFrameworkCore;
using eAutobus.Database;
using eAutobus.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


        public async Task<List<RasporedVoznjeModel>> Get(int RasporedLinijaID)
        {
            var linija =await  _context.RasporedVoznje.Include(r=>r.Recenzija).FirstOrDefaultAsync(r => r.RasporedVoznjeID == RasporedLinijaID);
            int ocjena=0;
            foreach (var o in linija.Recenzija)
            {
                ocjena += o.Ocjena;
            }
            linija.FinalOcjena = ocjena / linija.Recenzija.Count();
            return _mapper.Map<List<RasporedVoznjeModel>>(linija);

        }

        public async Task<RasporedVoznjeModel> GetById(int RasporedLinijaID)
        {
            var linija = _context.RasporedVoznje.Include(r => r.Recenzija)
                                                .Include(r => r.Odrediste)
                                                .Include(r => r.Polaziste)
                                                .Include(r => r.Autobus)
                                                .FirstOrDefault();
                                                                           
            decimal ocjena = 0;
            var linijaM = new RasporedVoznjeModel();
            _mapper.Map(linija, linijaM);
            linijaM.BrojAutobusa = linija.Autobus.BrojAutobusa;
            linijaM.Polazak = linija.Polaziste.NazivLokacijeStanice;
            linijaM.Odlazak = linija.Odrediste.NazivLokacijeStanice;
            linijaM.NazivLinije = linija.Polaziste.NazivLokacijeStanice + "-" + linija.Odrediste.NazivLokacijeStanice;
            foreach (var o in linija.Recenzija)
            {
                ocjena += o.Ocjena;
            }
            decimal brojRecenzija = linija.Recenzija.Count();
            linija.FinalOcjena = ocjena / brojRecenzija;
            return _mapper.Map<RasporedVoznjeModel>(linija);
        }
    }
}
