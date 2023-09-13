using eAutobusModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAutobus.Services.Interfaces
{
    public interface IPreporukeService
    {
        Task<List<RasporedVoznjeModel>> Recommend(int id);
    }
}
