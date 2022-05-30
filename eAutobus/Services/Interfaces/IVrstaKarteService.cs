using eAutobusModel;
using eAutobusModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAutobus.Services.Interfaces
{
    public interface IVrstaKarteService
    {
        Task<List<VrstaKarteModel>> Get();
        Task<VrstaKarteModel> GetById(int id);
        Task<VrstaKarteModel> Insert(VrstaKarteInsertRequest request);
        Task<VrstaKarteModel> Delete(int id);
        

    }
}
