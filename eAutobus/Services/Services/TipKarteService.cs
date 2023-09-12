using AutoMapper;
using eAutobus.Database;
using eAutobus.Services.Interfaces;
using eAutobusModel;
using eAutobusModel.Requests;
using Microsoft.EntityFrameworkCore;

namespace eAutobus.Services
{
    public class TipKarteService : ITipKarteService
    {
        private readonly Database.eAutobusi _context;
        private readonly IMapper _mapper;
        public TipKarteService(Database.eAutobusi context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<TipKarteModel> Delete(int id)
        {
            var entity = await _context.TipKarte.FirstOrDefaultAsync(x => x.TipKarteID == id);
            entity.IsDeleted = true;
            _context.SaveChanges();
            return _mapper.Map<TipKarteModel>(entity);
        }

        public async Task<List<TipKarteModel>> Get()
        {
            var list = await _context.TipKarte.ToListAsync();
            return _mapper.Map<List<TipKarteModel>>(list);
        }

        public async Task<TipKarteModel> GetById(int id)
        {
            var entity = await _context.TipKarte.FirstOrDefaultAsync(x => x.TipKarteID == id);
            return _mapper.Map<TipKarteModel>(entity);
        }

        public async Task<TipKarteModel> Insert(TipKarteInsertRequest request)
        {
            var entity = _mapper.Map<TipKarte>(request);
            _context.TipKarte.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<TipKarteModel>(entity);
        }
    }
}
