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
    public class TipKarteController : ControllerBase
    {
        private readonly ITipKarteService _service;
        public TipKarteController(ITipKarteService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<TipKarteModel>>> Get()
        {
            return Ok(await _service.Get());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TipKarteModel>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<TipKarteModel>> Insert(TipKarteInsertRequest request)
        {
            return Ok(await _service.Insert(request));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipKarteModel>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
