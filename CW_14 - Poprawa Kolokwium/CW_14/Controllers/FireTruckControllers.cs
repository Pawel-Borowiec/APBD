using CW_14.DAL;
using CW_14.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_14.Controllers
{
    [Route("api/firetrucks")]
    [ApiController]
    public class FireTruckControllers : ControllerBase
    {
        private readonly IDBService _service;

        public FireTruckControllers(IDBService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            MyDbContext _context = new MyDbContext();
            return Ok(_context.FireTrucks.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult getTruckById(int id)
        {
            return Ok(_service.getFireTruckById(id));
        }

    }
}
