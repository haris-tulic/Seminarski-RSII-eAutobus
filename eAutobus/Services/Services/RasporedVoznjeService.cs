using AutoMapper;
using eAutobus.Database;
using eAutobus.Services.Interfaces;
using eAutobusModel;
using eAutobusModel.Requests;
using Microsoft.EntityFrameworkCore;

namespace eAutobus.Services
{
    public class RasporedVoznjeService : IRasporedVoznjeService
    {
        private readonly eAutobusi _context;
        private readonly IMapper _mapper;
        public RasporedVoznjeService(eAutobusi context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<RasporedVoznjeModel> Delete(int id)
        {
            var entity = await _context.RasporedVoznje.FirstOrDefaultAsync(x => x.RasporedVoznjeID == id);
            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
            return _mapper.Map<eAutobusModel.RasporedVoznjeModel>(entity);
        }
        public async Task<List<RasporedVoznjeModel>> Get(RasporedVoznjeGetRequest search)
        {

            var query = _context.RasporedVoznje.Include(a => a.Autobus)
                .Include(o => o.Odrediste)
                .Include(d => d.Polaziste)
                .Include(r => r.Recenzija)
                .Include(v => v.Vozac)
                .Include(k => k.Kondukter)
                .Include("Vozac.Korisnik")
                .Where(i => i.IsDeleted == false).AsQueryable();
            if (search.OdredisteID.ToString() != "0")
            {
                query = query.Where(r => r.OdredisteID == search.OdredisteID);
            }
            if (search.PolazisteID.ToString() != "0")
            {
                query = query.Where(r => r.PolazisteID == search.PolazisteID);
            }
            if (!string.IsNullOrEmpty(search.Datum.ToString()) && search.Datum.Year > 1)
            {
                query = query.Where(r => r.Datum == search.Datum);
            }
            var list = await query.ToListAsync();
            var listR = new List<RasporedVoznjeModel>();
            _mapper.Map(list, listR);

            for (int i = 0; i < list.Count; i++)
            {
                listR[i].Odlazak = list[i].Odrediste.NazivLokacijeStanice;
                listR[i].Polazak = list[i].Polaziste.NazivLokacijeStanice;
                listR[i].BrojAutobusa = list[i].Autobus.BrojAutobusa;
                listR[i].NazivLinije = list[i].Polaziste.NazivLokacijeStanice + "-" + list[i].Odrediste.NazivLokacijeStanice;
                listR[i].VozacIme = list[i].Vozac.Korisnik.Ime;
                listR[i].Datum = DateTime.Parse(list[i].Datum.Date.ToString());
                listR[i].VrijemeDolaska = DateTime.Parse(list[i].VrijemeDolaska.ToString("T"));
                listR[i].VrijemePolaska = DateTime.Parse(list[i].VrijemePolaska.ToString("T"));
                listR[i].FinalOcjena = double.Parse(list[i].FinalOcjena.ToString());
            }

            return listR.OrderByDescending(r => r.FinalOcjena).ToList();
        }

        private RasporedVoznjeModel Convert(RasporedVoznje x)
        {
            RasporedVoznjeModel entity = new RasporedVoznjeModel
            {
                Polazak = x.Polaziste.NazivLokacijeStanice,
                Odlazak = x.Odrediste.NazivLokacijeStanice,
                BrojAutobusa = x.Autobus.BrojAutobusa,
                BrojLinije = x.BrojLinije,
                AutobusID = x.AutobusID,
                Datum =DateTime.Parse(x.Datum.ToString()),
                OdredisteID = x.OdredisteID,
                PolazisteID = x.PolazisteID,
                RasporedVoznjeID = x.RasporedVoznjeID,
                VozacIme = x.Vozac.Korisnik.Ime,
                NazivLinije = x.Polaziste.NazivLokacijeStanice + " " + x.Odrediste.NazivLokacijeStanice,
                VozacID = x.VozacID,
                VrijemeDolaska = DateTime.Parse(x.VrijemeDolaska.ToString("T")),
                VrijemePolaska = DateTime.Parse(x.VrijemePolaska.ToString("T")),
                KondukterID = x.KondukterID,
                FinalOcjena = double.Parse(x.FinalOcjena.ToString()),
            };
            return entity;
        }

        public async Task<RasporedVoznjeModel> GetById(int id)
        {
            var entity = await _context.RasporedVoznje.Include(a => a.Autobus)
                .Include(o => o.Odrediste)
                .Include(d => d.Polaziste)
                .Include(r => r.Recenzija)
                .Include(v => v.Vozac)
                .Include(k => k.Kondukter)
                .Include("Vozac.Korisnik").FirstOrDefaultAsync(x => x.RasporedVoznjeID == id);
            var entityk = Convert(entity);
            return entityk;
        }

        public async Task<RasporedVoznjeModel> Insert(RasporedVoznjeUpsertRequest request)
        {
            var entity = _mapper.Map<RasporedVoznje>(request);
            _context.RasporedVoznje.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<RasporedVoznjeModel>(entity);
        }

        public async Task<RasporedVoznjeModel> Update(RasporedVoznjeUpsertRequest request, int id)
        {
            var update = await _context.RasporedVoznje.FirstOrDefaultAsync(x => x.RasporedVoznjeID == id);
            _mapper.Map(request, update);
            await _context.SaveChangesAsync();
            return _mapper.Map<eAutobusModel.RasporedVoznjeModel>(update);
        }
    }
}
