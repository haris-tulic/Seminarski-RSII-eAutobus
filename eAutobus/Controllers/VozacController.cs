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
    public class VozacController : ControllerBase
    {
        private readonly IVozacService _service;
        public VozacController(IVozacService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<VozacModel>>> Get([FromQuery]VozacGetRequest request)
        {
            return Ok(await _service.Get(request));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VozacModel>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<VozacModel>> Insert(VozacUpsertRequest request)
        {
            return Ok(await _service.Insert(request));
        }
        [HttpPut("{id}")]

        public async Task<ActionResult<VozacModel>> Update(VozacUpsertRequest request, int id)
        {
            return Ok(await _service.Update(request, id));
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<VozacModel>> Delete(int id)
        {
            return  Ok(await _service.Delete(id));
        }
    }
}
