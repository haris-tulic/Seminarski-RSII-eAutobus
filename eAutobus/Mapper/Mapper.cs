using AutoMapper;
using eAutobusModel;
using eAutobusModel.Requests;
using eAutobus.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAutobus.Mapper
{
    public class Mapper:Profile
    {
        public Mapper() 
        {
            CreateMap<Autobus, AutobusiModel>().ReverseMap();
            CreateMap<AutobusInsertRequest, Autobus>().ReverseMap();

            CreateMap<AutobusVozac, AutobusVozacModel>().ReverseMap();
            CreateMap<AutobusVozacUpsertRequest, AutobusVozac>().ReverseMap();

            CreateMap<Cjenovnik, CjenovnikModel>().ReverseMap();
            CreateMap<CjenovnikInsertRequest, Cjenovnik>().ReverseMap();

            CreateMap<Garaza, GarazaModel>().ReverseMap();
            CreateMap<GarazaUpsertRequest, Garaza>().ReverseMap();

            CreateMap<Grad, GradModel>().ReverseMap();
            CreateMap<GradInsertRequest, Grad>().ReverseMap();
            
            CreateMap<Karta, KartaModel>().ReverseMap();
            CreateMap<KartaUpsertRequest, Karta>().ReverseMap();
            CreateMap<KartaUpsertRequest, KartaModel>().ReverseMap();
            
            CreateMap<Kupac, KupacModel>().ReverseMap();
            CreateMap<KupacInsertRequest, Kupac>().ReverseMap();
            
            CreateMap<RasporedVoznje, RasporedVoznjeModel>().ReverseMap();
            CreateMap<RasporedVoznjeUpsertRequest, RasporedVoznje>().ReverseMap();

            CreateMap<Stanica, StanicaModel>().ReverseMap();
            CreateMap<StanicaInsertRequest, Stanica>().ReverseMap();

            CreateMap<TipKarte, TipKarteModel>().ReverseMap();
            CreateMap<TipKarteInsertRequest, TipKarte>().ReverseMap();

            CreateMap<Korisnik, KorisnikModel>().ReverseMap();
            CreateMap<KorisnikUpsertRequest, Korisnik>().ReverseMap();

            CreateMap<Uloge, UlogeModel>().ReverseMap();
            CreateMap<UlogeInsertRequest, Uloge>().ReverseMap();



            CreateMap<Vozac, VozacModel>().ReverseMap();
            CreateMap<VozacUpsertRequest, Vozac>().ReverseMap();

            CreateMap<VrstaKarte, VrstaKarteModel>().ReverseMap();
            CreateMap<VrstaKarteInsertRequest, VrstaKarte>().ReverseMap();

            CreateMap<Zona, ZonaModel>().ReverseMap();
            CreateMap<ZonaInsertRequest, Zona>().ReverseMap();

            CreateMap<Korisnik, VozacModel>().ReverseMap();
            CreateMap<Korisnik, UpravaModel>().ReverseMap();
            CreateMap<Korisnik, KupacModel>().ReverseMap();

            CreateMap<KartaKupac, KartaKupacModel>().ReverseMap();
            CreateMap<KartaKupacUpsertRequest, KartaKupac>().ReverseMap();

            CreateMap<Recenzija, RecenzijaModel>().ReverseMap();
            CreateMap<RecenzijaUpsertRequest, Recenzija>().ReverseMap();

            CreateMap<PlatiKartu,PlatiKartuModel>().ReverseMap();
            CreateMap<PlatiKartuUpsertRequest, PlatiKartu>().ReverseMap();
        }
    }
}
