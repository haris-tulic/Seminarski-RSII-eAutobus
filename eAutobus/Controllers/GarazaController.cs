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
    public class GarazaController : ControllerBase
    {
        private readonly IGarazaService _service;

        public GarazaController(IGarazaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<GarazaModel>>> Get()
        {
           var response=await _service.Get();
           return Ok(response);     
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GarazaModel>> GetByID(int id)
        {
            var response=await _service.GetByID(id);
            return Ok(response);    
        }

        [HttpPost]
        public async Task<ActionResult<GarazaModel>> Insert(GarazaUpsertRequest request)
        {
            var response=await _service.Insert(request);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GarazaModel>> Update(GarazaUpsertRequest update,int id)
        {
            var response=await _service.Update(update,id);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GarazaModel>> Delete(int id)
        {
            var response=await _service.Delete(id);
            return Ok(response);
        }
    }
}
