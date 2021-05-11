using CW7.Models;
using CW7.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW7.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IDbService _service;

        public ClientController(IDbService Dbservice)
        {
            _service = Dbservice;
        }

        [HttpDelete("{idClient}")]
        public IActionResult deleteClient(int idClient)
        {
            int result = _service.DeleteClient(idClient);
            if (result!= 0)
            {
                return StatusCode(400, "You cant delete client whose already has Trips");
            }
            else
            {
                return Ok("Usunięto klienta o ID " + idClient);
            }

        }
    }
}
