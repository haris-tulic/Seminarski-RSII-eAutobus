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
using eAutobusModel;

namespace eAutobus.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class KartaController : ControllerBase
    {
        private readonly IKartaService _service;
        public KartaController(IKartaService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<KartaModel>>> Get([FromQuery] KartaGetRequest request)
        {
            var response = await _service.Get(request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<KartaModel>> GetById(int id)
        {
            var response = await _service.GetById(id);
            return Ok(response);

        }
        [HttpPost]
        public async Task<ActionResult<KartaModel>> Insert(KartaUpsertRequest request)
        {
            var response = await _service.Insert(request);
            return Ok(response);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<KartaModel>> Update(int id, KartaUpsertRequest request)
        {
            var response = await _service.Update(request, id);
            return Ok(response);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<KartaModel>> Delete(int id)
        {
            var response = await _service.Delete(id);
            return Ok(response);

        }
        [AllowAnonymous]
        [HttpPost("UplatiKartu/{id}")]
        public async Task<ActionResult<KartaModel>> UplatiKartu(int id,PlatiKartuUpsertRequest request)
        {
                var response = await _service.UplatiKartu(id,request);
                return Ok(response);
        }

    }
}
