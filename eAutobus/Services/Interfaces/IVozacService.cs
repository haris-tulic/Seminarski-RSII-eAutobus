using eAutobusModel;
using eAutobusModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAutobus.Services.Interfaces
{
    public interface IVozacService
    {
        Task<List<VozacModel>> Get(VozacGetRequest request);
        Task<VozacModel> GetById(int id);
        Task<VozacModel> Insert(VozacUpsertRequest request);
        Task<VozacModel> Update(VozacUpsertRequest request,int id);
        Task<VozacModel> Delete(int id);

    }
}
