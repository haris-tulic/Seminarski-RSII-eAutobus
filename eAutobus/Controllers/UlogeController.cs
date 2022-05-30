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
    public class UlogeController : ControllerBase
    {
        private readonly IUlogeService _service;

        public UlogeController(IUlogeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<UlogeModel>>> Get([FromQuery]UlogeGetRequest search)
        {
            return Ok(await _service.Get(search));
        }

        [HttpPost]
        public async Task<ActionResult<UlogeModel>> Insert(UlogeInsertRequest request)
        {
            return Ok(await _service.Insert(request));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UlogeModel>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UlogeModel>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UlogeModel>> Update(int id,UlogeInsertRequest request)
        {
            return Ok(await _service.Update(id, request));
        }     
       
    }
}
