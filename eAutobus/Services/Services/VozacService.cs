using AutoMapper;
using eAutobusModel;
using eAutobusModel.Requests;
using Microsoft.EntityFrameworkCore;
using eAutobus.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eAutobus.Services.Interfaces;

namespace eAutobus.Services
{
    public class VozacService:IVozacService
    {
        private readonly Database.eAutobusi _context;
        private readonly IMapper _mapper;
        public VozacService (Database.eAutobusi context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VozacModel> Delete(int id)
        {
            var entity = await _context.Vozac.FirstOrDefaultAsync(x=>x.VozacID==id);
            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
            return _mapper.Map<VozacModel>(entity);
        }

        public async Task<List<VozacModel>> Get(VozacGetRequest request)
        {
            var query = _context.Vozac.Include(v=>v.Korisnik).Where(v=>v.IsDeleted == true).AsQueryable();
            var list = await query.ToListAsync();
            var listM = new List<VozacModel>();
            _mapper.Map(list, listM);
            for (int i = 0; i < list.Count; i++)
            {
                listM[i].Ime = list[i].Korisnik.Ime;
                listM[i].Prezime = list[i].Korisnik.Prezime;
                listM[i].Email = list[i].Korisnik.Email;
                listM[i].DatumRodjenja = list[i].Korisnik.DatumRodjenja;

            }
            return listM;
        }

        public async Task<VozacModel> GetById(int id)
        {
            var entity = await _context.Vozac.FirstOrDefaultAsync(x=>x.VozacID==id);
            return _mapper.Map<VozacModel>(entity);
        }

        public async Task<VozacModel> Insert(VozacUpsertRequest request)
        {
            var novi = _mapper.Map<Vozac>(request);
            _context.Vozac.Add(novi);
            await _context.SaveChangesAsync();
            return _mapper.Map<VozacModel>(novi);
        }

        public async Task<VozacModel> Update(VozacUpsertRequest request, int id)
        {
            var update = await _context.Vozac.FirstOrDefaultAsync(x=>x.VozacID==id);
            _mapper.Map(request, update);
            await _context.SaveChangesAsync();
            return _mapper.Map<VozacModel>(update);

        }
    }
}
