using eAutobusModel;
using eAutobusModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAutobus.Services.Interfaces
{
    public interface IKorisnikService
    {
        Task<List<KorisnikModel>> Get(KorisnikGetRequest search);
        Task<KorisnikModel> GetByID(int id);
        Task<KorisnikModel> Insert(KorisnikUpsertRequest request);
        Task<KorisnikModel> Update(KorisnikUpsertRequest request,int id);
        Task<KorisnikModel> Delete(int id);
        //Task<KorisnikModel> Login(string username, string password);

    }
}
