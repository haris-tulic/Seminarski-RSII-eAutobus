using eAutobusModel;
using eAutobusModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAutobus.Services.Interfaces
{
    public interface IGarazaService
    {
        Task<List<GarazaModel>> Get();
        Task<GarazaModel> GetByID(int id);
        Task<GarazaModel> Insert(GarazaUpsertRequest request);
        Task<GarazaModel> Update(GarazaUpsertRequest update, int id);
        Task<GarazaModel> Delete(int id);
        Task<bool> IsPopunjeno(int GarazaId);
    }
}
