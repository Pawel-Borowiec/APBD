using CW10___Kolokwium.DAL;
using CW10___Kolokwium.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW10___Kolokwium.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IDBService _service;

        public PlayersController(IDBService service)
        {
            _service = service;
        }

        [HttpPost("{id}")]
        public IActionResult AddPlayer(Player player, int teamId)
        {
            int result = _service.AddPlayerToTeam(player, teamId);
            if (result == 2)
            {
                return StatusCode(400, "Zawodnik nie istnieje w bazie danych");
            }
            if (result == 3)
            {
                return StatusCode(400, "Zawodnik jest za stary dla tej drużyny");
            }
            if (result == 4)
            {
                return StatusCode(400, "Zawodnik jest już przypisany do tej drużyny");
            }
            return Ok("Dodano zawodnika do drużyny");
        }
    }
}
