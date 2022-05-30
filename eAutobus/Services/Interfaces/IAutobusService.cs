using eAutobusModel;
using eAutobusModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace eAutobus.Services.Interfaces
{
    public interface IAutobusService
    {
        Task<List<AutobusiModel>> Get(AutobusGetRequest request);
        Task<AutobusiModel> Insert(AutobusInsertRequest request);
        Task<AutobusiModel> Update(AutobusInsertRequest request,int id);
        Task<AutobusiModel> Delete(int id);
        Task<AutobusiModel> GetById(int id);
    }
}
