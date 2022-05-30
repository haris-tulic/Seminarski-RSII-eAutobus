using AutoMapper;
using eAutobus.Database;
using eAutobus.Services.Interfaces;
using eAutobusModel;
using eAutobusModel.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAutobus.Services
{
    public class AutobusService : IAutobusService
    {
        private readonly eAutobusi _context;
        private readonly IMapper _mapper;
        private readonly IGarazaService _garaza;

        public AutobusService(eAutobusi context, IMapper mapper, IGarazaService garaza)
        {
            _context = context;
            _mapper = mapper;
            _garaza = garaza;
        }
        public async Task<AutobusiModel> Delete(int id)
        {
            var entity = await _context.Autobus.FirstOrDefaultAsync(x => x.AutobusID == id);
            entity.IsDeleted = true;
            _context.SaveChanges();
            return _mapper.Map<AutobusiModel>(entity);
        }

        public async Task<List<AutobusiModel>> Get(AutobusGetRequest request)
        {
            var query =  _context.Autobus.Include(a=>a.Garaza).Where(a=>a.IsDeleted==false).AsQueryable();
            if (!string.IsNullOrEmpty(request.Marka))
            {
                query = query.Where(x => x.MarkaAutobusa.StartsWith(request.Marka));
                
            }
            var lista = await query.ToListAsync();
            var entityl = new List<AutobusiModel>();
            _mapper.Map(lista, entityl);
            for (int i = 0; i < lista.Count(); i++)
            {
                entityl[i].NazivGaraze = lista[i].Garaza.NazivGaraze;
            }
            return entityl;
        }

        public async Task<AutobusiModel> GetById(int id)
        {
            var entity =await _context.Autobus.FindAsync(id);
            return _mapper.Map<AutobusiModel>(entity);
        }

        public async Task<AutobusiModel> Insert(AutobusInsertRequest request)
        {
            var entity = _mapper.Map<Database.Autobus>(request);
            var garaza = await _garaza.GetByID(request.GarazaID);
            var IsPopunjeno = garaza.IsPopunjeno;
            if (!IsPopunjeno)
            {
                _context.Autobus.Add(entity);
                await _context.SaveChangesAsync();
                garaza.TrenutnoAutobusa++;
                return _mapper.Map<AutobusiModel>(entity);
            }
            else
            {
                throw new Exception("Garaža je popunjena!");
            }
           
        }

        public async Task<bool> Popunjeno(int GarazaId)
        {
            return await _garaza.IsPopunjeno(GarazaId);
        }

        public async Task<AutobusiModel> Update(AutobusInsertRequest request, int id)
        {
            var entity = _context.Autobus.Find(id);
            _mapper.Map(request, entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<AutobusiModel>(entity);
        }
    }
}
