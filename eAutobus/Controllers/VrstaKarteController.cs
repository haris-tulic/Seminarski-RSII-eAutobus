using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eAutobus.Services;
using eAutobusModel.Requests;
using Microsoft.AspNetCore.Authorization;
using eAutobus.Services.Interfaces;
using eAutobusModel;

namespace eAutobus.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VrstaKarteController : ControllerBase
    {
        private readonly IVrstaKarteService _service;
        public VrstaKarteController(IVrstaKarteService service)
        {
            _service = service;
        }
        [HttpGet]
       public async Task<ActionResult<List<VrstaKarteModel>>> Get()
        {
            return Ok(await _service.Get());
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<VrstaKarteModel>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpPost]
       public async Task<ActionResult<VrstaKarteModel>> Insert(VrstaKarteInsertRequest request)
        {

            return Ok(await _service.Insert(request));
        }
        [HttpDelete("{id}")]
       public async Task<ActionResult<VrstaKarteModel>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
