using AutoMapper;
using eAutobusModel;
using eAutobusModel.Requests;
using Microsoft.EntityFrameworkCore;
using eAutobus.Database;
using eAutobus.Exceptions;
using eAutobus.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace eAutobus.Services
{
    public class KupacService : IKupacService
    {
        
        private readonly eAutobusi _context;
        private readonly IMapper _mapper;
        private readonly IKorisnikService _korisnik;
        private readonly IKartaKupacService _kartaKupac;
        public KupacService(eAutobusi context, IMapper mapper, IKorisnikService korisnik, IKartaKupacService kartaKupac = null)
        {
            _context = context;
            _mapper = mapper;
            _korisnik = korisnik;
            _kartaKupac = kartaKupac;
        }
        public async Task<List<KupacModel>> Authentificiraj(string username, string password)
        {
            var entityK = await _context.Kupac.FirstOrDefaultAsync(k => k.KorisnickoIme == username);


            if (entityK != null)
            {
                var hash = GenerateHash(entityK.LozinkaSalt, password);
                if (hash != entityK.LozinkaHash)
                {
                    throw new UserException("Pogresan username ili password");
                }

                return _mapper.Map<List<KupacModel>>(entityK);
            }

            return null;

        }

        public async Task<KupacModel> Delete(int id)
        {
            var entity = await _context.Kupac.FirstOrDefaultAsync(x=>x.KupacID==id);
            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
            return _mapper.Map<KupacModel>(entity);
        }

        public async Task< List<KupacModel>> Get(KupacGetRequest request)
        {
            var query = _context.Kupac.Include(k=>k.KartaList).Include(k=>k.Recenzija).Where(k=>!k.IsDeleted).AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Ime))
            {
                query = query.Where(k => k.Ime.StartsWith(request.Ime));
            }
            if (!string.IsNullOrWhiteSpace(request.Prezime))
            {
                query = query.Where(k => k.Prezime.StartsWith(request.Prezime));
            }
            if (!string.IsNullOrWhiteSpace(request.UserName))
            {
                query = query.Where(k => k.KorisnickoIme == request.UserName);
            }

            var list = await query.ToListAsync();
            var listM = new List<KupacModel>();
            _mapper.Map(list, listM);
            if (list.Count()==1)
            {
                var search = new KartaKupacGetRequest();
                foreach (var item in list)
                {
                    search.KupacID = item.KupacID;
                }
                List<KartaKupacModel> listaKarata = await _kartaKupac.Get(search);
                for (int i = 0; i < listM.Count; i++)
                {
                    listM[i].KartaKupacs = listaKarata;
                }
            }
            return listM;
        }

        public async Task<KupacModel> GetByID(int id)
        {
            var entity = await _context.Kupac.Include(k=>k.KartaList).Include(k=>k.PlaceneKarte).FirstOrDefaultAsync(k=>k.KupacID==id && (!k.IsDeleted));
            var search = new KartaKupacGetRequest
            {
                KupacID = id,
            };
            var trazeniKupac = new KupacModel();
            _mapper.Map(entity, trazeniKupac);
            trazeniKupac.KartaKupacs = await _kartaKupac.Get(search);
            return trazeniKupac;
        }


        public async Task<KupacModel> Insert(KupacInsertRequest request)
        {
          
            var entity = _mapper.Map<Database.Kupac>(request);
            if (!string.IsNullOrEmpty(request.KorisnickoIme) && request.Password == request.PotvrdaPassworda)
            {
               
                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);
                var pronadji = await PronadjiKupca(request);
                if (pronadji!=null)
                {
                    return null;
                }
                else
                {
                    _context.Kupac.Add(entity);
                    await _context.SaveChangesAsync();
                }

                return _mapper.Map<KupacModel>(entity);
            }
            else
            {


                var pronadji = await PronadjiKupca(request);
                if (pronadji != null)
                {
                   await Update(request, pronadji.KupacID);
                }
                else
                {
                    _context.Kupac.Add(entity);
                    await _context.SaveChangesAsync();
                }

                return _mapper.Map<KupacModel>(entity);
            }
          
        }
        public async Task<KupacModel> RegistrujSe(KupacInsertRequest request)
        {

            var entity = _mapper.Map<Kupac>(request);
            if (!string.IsNullOrEmpty(request.KorisnickoIme) && request.Password == request.PotvrdaPassworda)
            {
               
                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);
            }
            var pronadji = PronadjiRegistrovanogKupca(request);
            if (pronadji != null)
            {
                throw new UserException("Korisnik već postoji!");
            }
            else
            {
                _context.Kupac.Add(entity);
               await _context.SaveChangesAsync();
            }

            return _mapper.Map<KupacModel>(entity);


        }

        public async Task<KupacModel> Update(KupacInsertRequest request,int id)
        {
            var entity = await _context.Kupac.FirstOrDefaultAsync(x=>x.KupacID==id);
            _mapper.Map(request, entity);
            if (!string.IsNullOrEmpty(entity.KorisnickoIme) && request.Password == request.PotvrdaPassworda)
            {
                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);
            }
            _context.Kupac.Update(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<KupacModel>(entity);


        }

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);

        }
        public async Task<Kupac> PronadjiKupca(KupacInsertRequest kupac)
        {
            var pronadji = await _context.Kupac
                .Include(x => x.KartaList).Include(x => x.PlaceneKarte).Include(x => x.Recenzija)
                .FirstOrDefaultAsync(k => k.Ime == kupac.Ime && k.Prezime == kupac.Prezime && k.BrojTelefona == kupac.BrojTelefona && k.KorisnickoIme == kupac.KorisnickoIme);


            return pronadji;
        }

        public Kupac PronadjiRegistrovanogKupca(KupacInsertRequest kupac)
        {
            var pronadji = _context.Kupac
                .Where(k => k.Ime == kupac.Ime && k.Prezime == kupac.Prezime && k.BrojTelefona == kupac.BrojTelefona && k.KorisnickoIme == kupac.KorisnickoIme && k.Email==kupac.Email)
                .Include(x => x.KartaList).Include(x => x.PlaceneKarte).Include(x => x.Recenzija)
                .Include("KartaList.Karta").Include("PlaceneKarte.Karta").FirstOrDefault();
            return pronadji;
        }

        
    }
}
