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

namespace SeminarskiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AutobusiController : ControllerBase
    {
        private readonly IAutobusService _service;
        public AutobusiController(IAutobusService service)
        {
            _service = service;
        }
        [HttpGet]

        public async Task<ActionResult<List<AutobusiModel>>> Get([FromQuery] AutobusGetRequest request)
        {
            var response = await _service.Get(request);
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<AutobusiModel>> Insert(AutobusInsertRequest request)
        {
            var response = await _service.Insert(request);
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<AutobusiModel>> Update(AutobusInsertRequest request, int id)
        {
            var response = await _service.Update(request, id);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<AutobusiModel>> Delete(int id)
        {
            var response = await _service.Delete(id);

            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AutobusiModel>> GetById(int id)
        {
            var response= await _service.GetById(id);
            return Ok(response);
        }
    }
}
