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
    public class AutobusVozacController : ControllerBase
    {
        private readonly IAutobusVozacService _service;

        public AutobusVozacController(IAutobusVozacService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<AutobusVozacModel>>> Get([FromQuery] AutobusVozacGetRequest request)
        {
            var response = await _service.Get(request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AutobusVozacModel>> GetByID(int id)
        {
            var response = await _service.GetByID(id);

            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<AutobusVozacModel>> Insert(AutobusVozacUpsertRequest request)
        {
         var response=await _service.Insert(request);
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<AutobusVozacModel>> Update(AutobusVozacUpsertRequest request, int id)
        {
            var response=await _service.Update(request, id);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<AutobusVozacModel>> Delete(int id)
        {
            var response=await  _service.Delete(id);
            return Ok(response);
        }
    }
}
