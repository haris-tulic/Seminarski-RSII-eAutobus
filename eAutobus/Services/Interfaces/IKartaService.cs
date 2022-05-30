using eAutobusModel;
using eAutobusModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAutobus.Services.Interfaces
{
    public interface IKartaService
    {
        Task<List<KartaModel>> Get(KartaGetRequest request);
        Task<KartaModel> GetById(int id);
        Task<KartaModel> Insert(KartaUpsertRequest request);
        Task<KartaModel> Update(KartaUpsertRequest request,int id);
        Task<KartaModel> Delete(int id);


    }
}
