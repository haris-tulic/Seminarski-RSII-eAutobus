using eAutobusModel;
using eAutobusModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAutobus.Services.Interfaces
{
    public interface IRecenzijaService
    {
        Task<List<RecenzijaModel>> Get(RecenzijaGetRequest search);
        Task<RecenzijaModel> Insert(RecenzijaUpsertRequest request);
        
    }
}
