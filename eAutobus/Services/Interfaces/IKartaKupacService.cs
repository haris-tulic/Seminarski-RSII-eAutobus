using eAutobusModel;
using eAutobusModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAutobus.Services.Interfaces
{
    public interface IKartaKupacService
    {
        Task<List<KartaKupacModel>> Get(KartaKupacGetRequest search);
        KartaKupacModel Insert(KartaKupacUpsertRequest request);
    }
}
