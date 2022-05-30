using AutoMapper;
using eAutobusModel.Requests;
using eAutobus.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eAutobus.Services.Interfaces;
using eAutobusModel;
using Microsoft.EntityFrameworkCore;

namespace eAutobus.Services
{
    public class VrstaKarteService:IVrstaKarteService
    {
        private readonly Database.eAutobusi _context;
        private readonly IMapper _mapper;
        public VrstaKarteService (Database.eAutobusi context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VrstaKarteModel> Delete(int id)
        {
            var entity = await _context.VrstaKarte.FirstOrDefaultAsync(x=>x.VrstaKarteID==id);
            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
            return _mapper.Map<VrstaKarteModel>(entity);
        }

        public async Task<List<VrstaKarteModel>> Get()
        {
            var lista = await _context.VrstaKarte.ToListAsync();
            return _mapper.Map<List<VrstaKarteModel>>(lista);
        }

        public async Task<VrstaKarteModel> GetById(int id)
        {
            var entity = await _context.VrstaKarte.FirstOrDefaultAsync(x=>x.VrstaKarteID==id);
            return _mapper.Map<VrstaKarteModel>(entity);
        }

        public async Task<VrstaKarteModel> Insert(VrstaKarteInsertRequest request)
        {
            var entity = _mapper.Map<VrstaKarte>(request);
            _context.VrstaKarte.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<VrstaKarteModel>(entity);
        }
    }
}
