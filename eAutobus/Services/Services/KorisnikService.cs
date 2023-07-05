using AutoMapper;
using eAutobusModel;
using eAutobusModel.Requests;
using Microsoft.EntityFrameworkCore;
using eAutobus.Database;
using eAutobus.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eAutobus.Services
{
    public class KorisnikService : IKorisnikService
    {
        private readonly eAutobusi _context;
        private readonly IMapper _mapper;
        private readonly IUlogeService _uloga;
        private readonly IVozacService _vozac;

        public KorisnikService(eAutobusi context, IMapper mapper, IUlogeService uloga, IVozacService vozac)
        {
            _context = context;
            _mapper = mapper;
            _uloga = uloga;
            _vozac = vozac;
        }

        public async Task<List<KorisnikModel>> Get(KorisnikGetRequest search)
        {
            var query = _context.Korisnik.Include(x=>x.Uloge).Where(k=>k.IsDeleted==false).AsQueryable();
            if (search.UlogaID.ToString()!="0" && !string.IsNullOrWhiteSpace(search.UlogaID.ToString()))
            {
                query = query.Where(k=>k.UlogeID==search.UlogaID);
            }
            if (!string.IsNullOrWhiteSpace(search.Ime))
            {
                query = query.Where(k => k.Ime.StartsWith(search.Ime));
            }
            if (!string.IsNullOrWhiteSpace(search.Prezime))
            {
                query = query.Where(k => k.Prezime.StartsWith(search.Prezime));
            }
            var list = await query.ToListAsync();
            var listM = _mapper.Map<List<KorisnikModel>>(list);
            for (int i = 0; i < list.Count(); i++)
            {
                listM[i].Uloga = list[i].Uloge.Naziv;
            }
            return listM;
        }
              
        public async Task<KorisnikModel> GetByID(int id)
        {
            var entity = await _context.Korisnik.FirstOrDefaultAsync(x=>x.KorisnikID==id);
            return _mapper.Map<KorisnikModel>(entity);
        }

        public async Task<KorisnikModel> Insert(KorisnikUpsertRequest request)
        {
            if (request.Password!=request.PasswordPotrvda)
            {
                throw new Exception("Passwordi se ne slažu!");
            }
            var entity = _mapper.Map<Korisnik>(request);
            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);
            _context.Korisnik.Add(entity);
            await _context.SaveChangesAsync();
            var uloga = await _uloga.GetById(request.UlogeID);
            if (uloga.Naziv=="Vozač" || uloga.Naziv=="Kondukter")
            {
                var vozac = new VozacUpsertRequest()
                {
                    KorisnikID = entity.KorisnikID,
                    VozackaKategorija = "B" + ", " + "C" + ", " + "D",
                    
                };
                _vozac.Insert(vozac);
            }
            return _mapper.Map<KorisnikModel>(entity);
        }

        public async Task<KorisnikModel> Delete(int id)
        {
            var entity = _context.Korisnik.Find(id);
            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
            return _mapper.Map<KorisnikModel>(entity);
        }

        public async Task<KorisnikModel> Update(KorisnikUpsertRequest request, int id)
        { 
            var entity = await _context.Korisnik.FirstOrDefaultAsync(x=>x.KorisnikID==id);
            _mapper.Map(request, entity);
            if (!string.IsNullOrEmpty(request.Password))
            {
                if (request.Password == request.PasswordPotrvda)
                {
                    entity.LozinkaSalt = GenerateSalt();
                    entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);

                }
                else
                {
                    throw new Exception("Nemoguće izmijeniti password!");
                }
            }
            
           await _context.SaveChangesAsync();
            return _mapper.Map<KorisnikModel>(entity);
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
            System.Buffer.BlockCopy(bytes, 0, dst,src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);

        }

      
    }
}
