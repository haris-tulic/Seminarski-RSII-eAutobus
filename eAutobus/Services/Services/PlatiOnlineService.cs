using AutoMapper;
using eAutobusModel.Requests;
using eAutobus.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eAutobus.Database;
using Microsoft.EntityFrameworkCore;
using eAutobusModel;

namespace eAutobus.Services
{
    public class PlatiOnlineService : IPlatiOnlineService
    {
        private readonly eAutobusi _context;
        private readonly IMapper _mapper;
        public PlatiOnlineService(eAutobusi context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PlatiKartuModel>> Get(PlatiKartuGetRequest search)
        {
            var query = _context.PlatiKartu.Include(x => x.Kupac)
                                              .Include(x => x.Karta)
                                              .Include("Karta.TipKarte")
                                              .Include("Karta.VrstaKarte")
                                              .Include("Karta.Polaziste")
                                              .Include("Karta.Odrediste")
                                              .AsQueryable();
            var list = await query.ToListAsync();
            var listM = new List<PlatiKartuModel>();
            _mapper.Map(list, listM);
            for (int i = 0; i < list.Count; i++)
            {
                listM[i].ImePrezimeKupca = list[i].Kupac.Ime + " " + list[i].Kupac.Prezime;
                listM[i].TipKarteNaziv = list[i].Karta.TipKarte.Naziv;
                listM[i].VrstaKarteNaziv = list[i].Karta.VrstaKarte.Naziv;
                listM[i].PolazisteOdrediste = list[i].Karta.Polaziste.NazivLokacijeStanice + " - " + list[i].Karta.Odrediste.NazivLokacijeStanice;
            }
            return listM;
        }

        public async Task<PlatiKartuModel> GetById(int id)
        {
            var entity = await _context.PlatiKartu.Include(x => x.Kupac).Include(x => x.Karta).FirstOrDefaultAsync(k=>k.PlatiKartuID==id);
            return _mapper.Map<PlatiKartuModel>(entity);
        }

        public async Task<PlatiKartuModel> Insert(PlatiKartuUpsertRequest request)
        {
            var entity = _mapper.Map<PlatiKartu>(request);
            _context.PlatiKartu.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<PlatiKartuModel>(entity);
        }

        public async Task<PlatiKartuModel>Update(PlatiKartuUpsertRequest request,int id)
        {
            var entity = await _context.PlatiKartu.FirstOrDefaultAsync(p=>p.PlatiKartuID==id);
            _mapper.Map(request, entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<PlatiKartuModel>(entity);
        }
    }
}
