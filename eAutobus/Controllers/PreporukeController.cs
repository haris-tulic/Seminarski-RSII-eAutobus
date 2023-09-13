using eAutobusModel;
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
    [Route("api/[controller]")]
    [ApiController]
    public class PreporukeController : ControllerBase
    {
        private readonly IPreporukeService _service;

        public PreporukeController(IPreporukeService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<RasporedVoznjeModel>>> Recommend(int id)
        {
            var response = await _service.Recommend(id);
            return Ok(response);

        }
    }
}
