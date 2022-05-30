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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RasporedVoznjeController : ControllerBase
    {
        private readonly IRasporedVoznjeService _service;
        public RasporedVoznjeController(IRasporedVoznjeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<RasporedVoznjeModel>>> Get([FromQuery]RasporedVoznjeGetRequest search)
        {
            var response=await  _service.Get(search);
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<RasporedVoznjeModel>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }
     
        [HttpPost]
        public async Task<ActionResult<RasporedVoznjeModel>> Insert(RasporedVoznjeUpsertRequest request)
        {
            return Ok(await _service.Insert(request));
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<RasporedVoznjeModel>> Update(RasporedVoznjeUpsertRequest request, int id)
        {
            return Ok(await _service.Update(request, id));
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<RasporedVoznjeModel>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
