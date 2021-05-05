using CW8.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW8.Controllers
{
    [Route("api/prescriptions")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IDbService _service;

        public PrescriptionController(IDbService service)
        {
            _service = service;
        }

        [HttpGet("{Id}")]
        public IActionResult getPrescription(int Id)
        {
            return Ok(_service.GetPrescription(Id));
        }
    }
}
