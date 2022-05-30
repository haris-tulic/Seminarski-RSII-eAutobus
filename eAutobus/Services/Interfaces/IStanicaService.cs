using eAutobusModel;
using eAutobusModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAutobus.Services.Interfaces
{
    public interface IStanicaService
    {
        Task<List<StanicaModel>> Get();
        Task<StanicaModel> GetById(int id);
        Task<StanicaModel> Insert(StanicaInsertRequest request);
        Task<StanicaModel> Delete(int id);
    }
}
