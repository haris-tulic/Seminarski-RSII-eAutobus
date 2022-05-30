using eAutobusModel;
using eAutobusModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAutobus.Services.Interfaces
{
    public interface ICjenovnikService
    {
        Task<List<CjenovnikModel>> Get(CjenovnikSearchRequest request);
        Task<CjenovnikModel> GetByID(int id);
        Task<CjenovnikModel> Insert(CjenovnikInsertRequest request);
        Task<CjenovnikModel> Update( int id, CjenovnikInsertRequest request);
        Task<CjenovnikModel> Delete(int id);
        Task<CjenovnikModel> GetCijena(CjenovnikSearchRequest request);


    }
}
