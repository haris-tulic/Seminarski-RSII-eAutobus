using eAutobusModel;
using eAutobusModel.Requests;
using eAutobus.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAutobus.Services.Interfaces
{
    public interface IKupacService
    {
       Task<KupacModel> GetByID(int id);
       Task<List<KupacModel>> Get(KupacGetRequest request);
       Task<KupacModel> Insert(KupacInsertRequest request);
       Task<KupacModel> Update(KupacInsertRequest request,int id);
       Task<KupacModel> Delete(int id);
       Task<Kupac> PronadjiKupca(KupacInsertRequest kupac);
       Task<KupacModel> RegistrujSe(KupacInsertRequest request);
    }
}
