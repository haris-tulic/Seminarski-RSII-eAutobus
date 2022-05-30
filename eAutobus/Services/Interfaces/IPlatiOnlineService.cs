using eAutobusModel;
using eAutobusModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAutobus.Services.Interfaces
{
    public interface IPlatiOnlineService
    {
       Task<List<PlatiKartuModel>> Get(PlatiKartuGetRequest search);
       Task<PlatiKartuModel> GetById(int id);
       Task<PlatiKartuModel> Insert(PlatiKartuUpsertRequest request);
       Task<PlatiKartuModel> Update(PlatiKartuUpsertRequest request,int id);

    }
}
