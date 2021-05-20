using CW8.DAL;
using CW8.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW8.Controllers
{
    [Authorize]
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDbService _service;

        public DoctorsController(IDbService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_service.GetDoctors());
        }
        [HttpPost]
        public IActionResult AddDoctor(Doctor doctor)
        {
            return Ok(_service.AddDoctor(doctor));
        }
        [HttpPut("{id}")]
        public IActionResult UpdateDoctor(Doctor doctor, int id)
        {
            return Ok(_service.UpdateDoctor(doctor));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            return Ok(_service.DeleteDoctor(id));
        }
    }
}
