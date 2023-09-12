using AutoMapper;
using eAutobus.Database;
using eAutobus.Services.Interfaces;
using eAutobusModel;
using eAutobusModel.Requests;
using Microsoft.EntityFrameworkCore;

namespace eAutobus.Services
{
    public class GradService : IGradService
    {
        private readonly eAutobusi _context;
        private readonly IMapper _mapper;
        public GradService(Database.eAutobusi context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GradModel> Delete(int id)
        {
            var entity = _context.Grad.Find(id);
            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
            return _mapper.Map<GradModel>(entity);

        }

        public async Task<List<GradModel>> Get()
        {
            var list = await _context.Grad.ToListAsync();
            return _mapper.Map<List<GradModel>>(list);
        }

        public async Task<GradModel> GetById(int id)
        {
            var entity = await _context.Grad.FirstOrDefaultAsync(g => g.GradID == id);
            return _mapper.Map<GradModel>(entity);
        }

        public async Task<GradModel> Insert(GradInsertRequest request)
        {
            var entity = _mapper.Map<Grad>(request);
            _context.Grad.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<GradModel>(entity);
        }

        public async Task<GradModel> Update(GradInsertRequest request, int id)
        {
            var entity = await _context.Grad.FirstOrDefaultAsync(g => g.GradID == id);
            _mapper.Map(request, entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<GradModel>(entity);
        }
    }
}
