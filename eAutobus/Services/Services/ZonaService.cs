using AutoMapper;
using eAutobus.Database;
using eAutobus.Services.Interfaces;
using eAutobusModel;
using eAutobusModel.Requests;
using Microsoft.EntityFrameworkCore;

namespace eAutobus.Services
{
    public class ZonaService : IZonaService
    {
        private readonly Database.eAutobusi _context;
        private readonly IMapper _mapper;
        public ZonaService(eAutobusi context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ZonaModel> Delete(int id)
        {
            var entity = await _context.Zona.FirstOrDefaultAsync(c => c.ZonaID == id);
            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
            return _mapper.Map<ZonaModel>(entity);
        }

        public async Task<List<ZonaModel>> Get()
        {
            var list = await _context.Zona.ToListAsync();
            return _mapper.Map<List<ZonaModel>>(list);
        }

        public async Task<ZonaModel> GetById(int id)
        {
            var entity = await _context.Zona.FirstOrDefaultAsync(x => x.ZonaID == id);
            return _mapper.Map<ZonaModel>(entity);
        }

        public async Task<ZonaModel> Insert(ZonaInsertRequest request)
        {
            var entity = _mapper.Map<Database.Zona>(request);
            _context.Zona.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ZonaModel>(entity);
        }
    }
}
