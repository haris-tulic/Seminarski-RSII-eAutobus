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
    public class GradController : ControllerBase
    {
        private readonly IGradService _service;
        public GradController(IGradService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<GradModel>>> Get()
        {
            var response=await _service.Get();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GradModel>> GetById(int id)
        {
            var response = await _service.GetById(id);
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<GradModel>> Insert(GradInsertRequest request)
        {
            var response = await _service.Insert(request);
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<GradModel>> Update(GradInsertRequest request, int id)
        {
            var response=await _service.Update(request, id);
            return Ok(response);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<GradModel>> Delete(int id)
        {
            var response= _service.Delete(id);
            return Ok(response);
        }
    }
}
