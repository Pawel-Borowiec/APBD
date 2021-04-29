using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW8.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult AddDoctor()
        {
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateDoctor()
        {
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteDoctor()
        {
            return Ok();
        }
    }
}
