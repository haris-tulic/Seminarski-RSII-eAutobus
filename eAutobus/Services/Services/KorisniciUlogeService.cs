using AutoMapper;
using eAutobusModel;
using eAutobus.Database;
using eAutobus.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAutobus.Services
{
    public class KorisniciUlogeService : IKorisniciUlogeService
    {
        private readonly eAutobusi _context;
        private readonly IMapper _mapper;

        public KorisniciUlogeService(eAutobusi context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<KorisniciUlogeModel> UlogeIsEqual(int ulogaID)
        {
            var equal = _context.KorisniciUloge.Where(x => x.UlogaID == ulogaID).ToList();
            return _mapper.Map <List<KorisniciUlogeModel>>(equal);
        }
    }
}
