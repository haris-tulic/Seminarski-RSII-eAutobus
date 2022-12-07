using eAutobusModel;
using eAutobusModel.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eAutobus.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eAutobus.Services.Interfaces;

namespace eAutobus.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class KupacController : ControllerBase
    {
        private readonly IKupacService _service;
        public KupacController(IKupacService service)
        {
            _service = service;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<KupacModel>>> Get([FromQuery]KupacGetRequest request)
        {
            var response=await _service.Get(request);
            return Ok(response);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<KupacModel>> GetByID(int id)
        {
            var response = await _service.GetByID(id);
            return Ok(response);

        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<KupacModel>> Insert(KupacInsertRequest request)
        {
            var response = await _service.Insert(request);
            return Ok(response);

        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<ActionResult<KupacModel>> Update(KupacInsertRequest request, int id)
        {
            var response = await _service.Update(request, id);
            return Ok(response);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<KupacModel>> Delete(int id)
        {
            var response = await _service.Delete(id);
            return Ok(response);

        }
        [AllowAnonymous]
        [HttpPost("{request}")]
        public async Task<ActionResult<KupacModel>> RegistrujSe(KupacInsertRequest request)
        {
            var response = await _service.RegistrujSe(request);
            return Ok(response);
        }

    }
}
