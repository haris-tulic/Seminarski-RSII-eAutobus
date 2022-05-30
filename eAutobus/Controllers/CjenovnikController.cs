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
    public class CjenovnikController : ControllerBase
    {
        private ICjenovnikService _service;
        public CjenovnikController(ICjenovnikService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<CjenovnikModel>>> Get([FromQuery] CjenovnikSearchRequest request)
        {
            var response=await _service.Get(request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CjenovnikModel>> GetByID(int id)
        {
            var response=await _service.GetByID(id);
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<CjenovnikModel>> Insert(CjenovnikInsertRequest request)
        {
            var response=await  _service.Insert(request);
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<CjenovnikModel>> Update(int id, CjenovnikInsertRequest request)
        {
            var response=await _service.Update(id, request) ;
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<CjenovnikModel>> Delete(int id)
        {
            var response=await  _service.Delete(id);
            return Ok(response);
        }
       
    }
}
