using eAutobusModel;
using eAutobusModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAutobus.Services.Interfaces
{
    public interface IAutobusVozacService
    {
        Task<List<AutobusVozacModel>> Get(AutobusVozacGetRequest request);
        Task<AutobusVozacModel> GetByID(int id);
        Task<AutobusVozacModel> Insert(AutobusVozacUpsertRequest request);
        Task<AutobusVozacModel> Update(AutobusVozacUpsertRequest request,int id);
        Task<AutobusVozacModel> Delete(int id);

    }
}
