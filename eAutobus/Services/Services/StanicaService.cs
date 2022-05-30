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
    public class StanicaService : IStanicaService
    {
        private readonly eAutobusi _context;
        private readonly IMapper _mapper;
        public StanicaService(Database.eAutobusi context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StanicaModel> Delete(int id)
        {
            var entity = await _context.Stanica.FirstOrDefaultAsync(x=>x.StanicaID==id);
            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
            return _mapper.Map<StanicaModel>(entity);
        }

        public async Task<List<StanicaModel>> Get()
        {
            var list = await _context.Stanica.Include(s=>s.Grad).ToListAsync();
            var listS = new List<StanicaModel>();
            listS = _mapper.Map<List<StanicaModel>>(list);
            for (int i = 0; i < list.Count(); i++)
            {
                listS[i].Grad = list[i].Grad.NazivGrada;
            }
            return listS ;
        }

        public async Task<StanicaModel> GetById(int id)
        {
            var entity = _context.Stanica.FirstOrDefaultAsync(x=>x.StanicaID==id);
            return _mapper.Map<StanicaModel>(entity);
        }

        public async Task< StanicaModel> Insert(StanicaInsertRequest request)
        {
            var entity = _mapper.Map<Database.Stanica>(request);
            _context.Stanica.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<StanicaModel>(entity);

        }
    }
}
