using eAutobusModel;
using eAutobus.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAutobus.Services.Interfaces
{
    public interface IKorisniciUlogeService
    {
        List<KorisniciUlogeModel> UlogeIsEqual(int ulogaID); 
    }
}
