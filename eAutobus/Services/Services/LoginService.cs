﻿using AutoMapper;
using eAutobus.Database;
using eAutobus.Exceptions;
using eAutobus.Services.Interfaces;
using eAutobusModel;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace eAutobus.Services
{
    public class LoginService : ILoginService
    {
        private readonly eAutobusi _context;
        private readonly IMapper _mapper;

        public LoginService(IMapper mapper, eAutobusi context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<KorisnikModel> Autentificiraj(string userName, string password)
        {
            var entity = await _context.Korisnik.Include(x => x.Uloge).FirstOrDefaultAsync(u => u.KorisnickoIme == userName);
            var entityK = await _context.Kupac.FirstOrDefaultAsync(k => k.KorisnickoIme == userName);


            if (entity != null)
            {
                var hash = GenerateHash(entity.LozinkaSalt, password);
                if (hash != entity.LozinkaHash)
                {
                    throw new UserException("Pogresan username ili password");
                }

                return _mapper.Map<KorisnikModel>(entity);
            }
            else if (entityK != null)
            {



                var hash = GenerateHash(entityK.LozinkaSalt, password);
                if (hash != entityK.LozinkaHash)
                {
                    throw new UserException("Pogresan username ili password");
                }
                UlogeModel nova = new UlogeModel
                {
                    Naziv = "Kupac",
                    Opis = "Kupovina karata",

                };

                KorisnikModel kupac = new KorisnikModel
                {
                    KorisnikID = entityK.KupacID,
                    Ime = entityK.Ime,
                    KorisnickoIme = entityK.KorisnickoIme,
                    Prezime = entityK.Prezime,
                    Uloga = nova.Naziv,
                    Uloge = nova,
                    BrojTelefona = entityK.BrojTelefona,
                    AdresaStanovanja = entityK.AdresaStanovanja,
                };
                return kupac;
            }
            return null;

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
    }
}
