using eAutobusModel;
using eAutobusModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAutobus.Services.Interfaces
{
    public interface IZonaService
    {
        Task<List<ZonaModel>> Get();
        Task<ZonaModel> GetById(int id);
        Task<ZonaModel> Insert(ZonaInsertRequest request);
        Task<ZonaModel> Delete(int id);
    }
}
