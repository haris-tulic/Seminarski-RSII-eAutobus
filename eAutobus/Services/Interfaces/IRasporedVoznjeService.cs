using eAutobusModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAutobus.Services.Interfaces
{
    public interface IRasporedVoznjeService
    {
        Task<List<eAutobusModel.RasporedVoznjeModel>> Get(RasporedVoznjeGetRequest search);
        Task<eAutobusModel.RasporedVoznjeModel> GetById(int id);
        Task<eAutobusModel.RasporedVoznjeModel> Insert(RasporedVoznjeUpsertRequest request);
        Task<eAutobusModel.RasporedVoznjeModel> Update(RasporedVoznjeUpsertRequest request, int id);
        Task<eAutobusModel.RasporedVoznjeModel> Delete(int id);
    }
}
