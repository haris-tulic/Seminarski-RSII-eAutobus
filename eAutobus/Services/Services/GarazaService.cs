using AutoMapper;
using eAutobus.Database;
using eAutobus.Services.Interfaces;
using eAutobusModel;
using eAutobusModel.Requests;
using eAutobus.Database;
using eAutobus.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace eAutobus.Services
{
    public class GarazaService : IGarazaService
    {
        private readonly eAutobusi _context;
        private readonly IMapper _mapper;
        public GarazaService(Database.eAutobusi context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GarazaModel>> Get()
        {
            var list =await _context.Garaza.ToListAsync();
            return _mapper.Map<List<GarazaModel>>(list);
        }

        public async Task<GarazaModel> GetByID(int id)
        {
            var entity =await _context.Garaza.FirstOrDefaultAsync(i=>i.GarazaID==id);
            return _mapper.Map<GarazaModel>(entity);
        }

        public async Task<GarazaModel> Insert(GarazaUpsertRequest request)
        {
            var entity = _mapper.Map<Garaza>(request);
            _context.Garaza.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<GarazaModel>(entity);
        }

        public async Task<GarazaModel> Update(GarazaUpsertRequest update, int id)
        {
            var entity =await  _context.Garaza.FirstOrDefaultAsync(i => i.GarazaID == id);
            _mapper.Map(update, entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<GarazaModel>(entity);
        }

        public async Task<GarazaModel> Delete(int id)
        {
            var entity =await _context.Garaza.FirstOrDefaultAsync(g=>g.GarazaID==id);
            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
            return _mapper.Map<GarazaModel>(entity);
        }
        public async Task<bool> IsPopunjeno(int GarazaID)
        {
            var entity = await _context.Garaza.FirstOrDefaultAsync(g=>g.GarazaID ==GarazaID);
            if (entity.IsPopunjeno==true || entity.TrenutnoAutobusa>=entity.BrojMjesta)
            {
                entity.IsPopunjeno = true;
                return entity.IsPopunjeno;
            }
            else
            {
                return entity.IsPopunjeno;
            }
        }
    }
}
