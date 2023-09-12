using AutoMapper;
using eAutobus.Database;
using eAutobus.Services.Interfaces;
using eAutobusModel;
using eAutobusModel.Requests;
using Microsoft.EntityFrameworkCore;

namespace eAutobus.Services
{
    public class AutobusVozacService : IAutobusVozacService
    {
        private readonly eAutobusi _context;
        private readonly IMapper _mapper;
        public AutobusVozacService(eAutobusi context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AutobusVozacModel> Delete(int id)
        {
            var entity = await _context.AutobusVozac.FirstOrDefaultAsync(x => x.AutobusVozacID == id);
            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
            return _mapper.Map<AutobusVozacModel>(entity);
        }

        public async Task<List<AutobusVozacModel>> Get(AutobusVozacGetRequest request)
        {
            var query = _context.AutobusVozac.Include(a => a.Autobus).Include(v => v.Vozac).AsQueryable();
            return _mapper.Map<List<AutobusVozacModel>>(query);
        }

        public async Task<AutobusVozacModel> GetByID(int id)
        {
            var obj = await _context.AutobusVozac.FirstOrDefaultAsync(x => x.AutobusVozacID == id);
            return _mapper.Map<AutobusVozacModel>(obj);

        }

        public async Task<AutobusVozacModel> Insert(AutobusVozacUpsertRequest request)
        {
            var entity = _mapper.Map<Database.AutobusVozac>(request);
            _context.AutobusVozac.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<AutobusVozacModel>(entity);
        }

        public async Task<AutobusVozacModel> Update(AutobusVozacUpsertRequest request, int id)
        {
            var entity = _context.AutobusVozac.Find(id);
            _mapper.Map(request, entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<AutobusVozacModel>(entity);

        }
    }
}
