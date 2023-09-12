using AutoMapper;
using eAutobus.Database;
using eAutobus.Services.Interfaces;
using eAutobusModel;
using eAutobusModel.Requests;
using Microsoft.EntityFrameworkCore;

namespace eAutobus.Services.Services
{
    public class RecenzijaService : IRecenzijaService
    {
        private readonly eAutobusi _context;
        private readonly IMapper _mapper;
        private readonly IRasporedVoznjeService _rasporedVoznjeService;

        public RecenzijaService(eAutobusi context, IMapper mapper, IRasporedVoznjeService rasporedVoznjeService)
        {
            _context = context;
            _mapper = mapper;
            _rasporedVoznjeService = rasporedVoznjeService;
        }

        public async Task<List<RecenzijaModel>> Get(RecenzijaGetRequest search)
        {
            var query = _context.Recenzija.Include(x => x.RasporedVoznje).Include(x => x.Kupac).Include("RasporedVoznje.Polaziste").Include("RasporedVoznje.Odrediste").AsQueryable();
            if (search.Ocjena > 0 && search.Ocjena <= 5)
            {
                query = query.Where(x => x.Ocjena == search.Ocjena);
            }
            var list = await query.ToListAsync();
            var listM = new List<RecenzijaModel>();
            _mapper.Map(list, listM);
            for (int i = 0; i < list.Count; i++)
            {
                listM[i].RasporedVoznje = list[i].RasporedVoznje.Polaziste.NazivLokacijeStanice + "-" + list[i].RasporedVoznje.Odrediste.NazivLokacijeStanice;
                listM[i].ImePrezimeKupca = list[i].Kupac.Ime + " " + list[i].Kupac.Prezime;
            }
            return listM;
        }

        public async Task<RecenzijaModel> Insert(RecenzijaUpsertRequest request)
        {
            var entity = _mapper.Map<Recenzija>(request);
            _context.Recenzija.Add(entity);
            var linija = await _context.RasporedVoznje.Include(r => r.Recenzija).FirstOrDefaultAsync(r => r.RasporedVoznjeID == request.RasporedVoznjeID);
            int ocjena = 0;
            foreach (var item in linija.Recenzija)
            {
                ocjena += item.Ocjena;
            }
            if (linija.Recenzija.Count() > 0)
                linija.FinalOcjena = ocjena / linija.Recenzija.Count();

            await _context.SaveChangesAsync();

            return _mapper.Map<RecenzijaModel>(entity);
        }

    }
}
