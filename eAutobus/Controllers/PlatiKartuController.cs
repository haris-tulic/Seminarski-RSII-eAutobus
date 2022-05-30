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
    public class PlatiKartuController : ControllerBase
    {
        private readonly IPlatiOnlineService _service;

        public PlatiKartuController(IPlatiOnlineService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<PlatiKartuModel>>> Get([FromQuery]PlatiKartuGetRequest search)
        {
            var response=await _service.Get(search);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlatiKartuModel>> GetById(int id)
        {
            var response = await _service.GetById(id);
            return Ok(response);

        }

        [HttpPost]
    public async Task<ActionResult<PlatiKartuModel>> Insert(PlatiKartuUpsertRequest request)
        {
            var response = await _service.Insert(request);
            return Ok(response);

        }

        [HttpPut("{id}")]
public async Task<ActionResult<PlatiKartuModel>> Update(PlatiKartuUpsertRequest request, int id)
        {
            var response = await _service.Update(request,id);
            return Ok(response);
        }
    }
}
