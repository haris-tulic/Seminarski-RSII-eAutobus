using eAutobusModel;
using eAutobusModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAutobus.Services.Interfaces
{
    public interface ITipKarteService
    {
        Task<List<TipKarteModel>> Get();
        Task<TipKarteModel> GetById(int id);
        Task<TipKarteModel> Insert(TipKarteInsertRequest request);
        Task<TipKarteModel> Delete(int id);


    }
}
