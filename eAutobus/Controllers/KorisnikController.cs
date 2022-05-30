using eAutobusModel;
using eAutobusModel.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eAutobus.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAutobus.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    

    public class KorisnikController : ControllerBase
    {
        private readonly IKorisnikService _service;

        public KorisnikController(IKorisnikService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<KorisnikModel>>> Get([FromQuery]KorisnikGetRequest search)
        {
            var response=await _service.Get(search);
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<KorisnikModel>> GetByID(int id)
        {
            var response = await _service.GetByID(id);
            return Ok(response);

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<KorisnikModel>> Insert(KorisnikUpsertRequest request)
        {
            var response = await  _service.Insert(request);
            return Ok(response);

        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<KorisnikModel>> Update(KorisnikUpsertRequest request, int id)
        {
            var response = await _service.Update(request, id);
            return Ok(response);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<KorisnikModel>> Delete(int id)
        {
            var response = await _service.Delete(id);
            return Ok(response);
        }
    }

}
