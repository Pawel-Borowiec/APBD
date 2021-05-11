using CW10___Kolokwium.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW10___Kolokwium.Controllers
{
    [Route("api/championships")]
    [ApiController]
    public class TeamController : ControllerBase
    {

        private readonly IDBService _service;

        public TeamController(IDBService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetTeamsOnChampionship()
        {
            return Ok();
        }
    }
}
