using eAutobusModel;
using eAutobusModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAutobus.Services.Interfaces
{
    public interface IGradService
    {
        Task<List<GradModel>> Get();
        Task<GradModel> GetById(int id);
        Task<GradModel> Insert(GradInsertRequest request);
        Task<GradModel> Update(GradInsertRequest request, int id);
        Task<GradModel> Delete(int id);
    }
}
