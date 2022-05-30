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
    public class RecenzijaController : ControllerBase
    {
        private readonly IRecenzijaService _service;

        public RecenzijaController(IRecenzijaService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<RecenzijaModel>>> Get([FromQuery] RecenzijaGetRequest search)
        {
            return Ok(await _service.Get(search));
        }

        [HttpPost]
        public async Task<ActionResult<RecenzijaModel>> Insert(RecenzijaUpsertRequest request)
        {
            return Ok(await _service.Insert(request));
        }
    }
}
