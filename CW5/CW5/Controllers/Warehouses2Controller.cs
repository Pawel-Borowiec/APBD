using CW5.DAL;
using CW5.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW5.Controllers
{
    [Route("api/warehouses2")]
    [ApiController]
    public class Warehouses2Controller : ControllerBase
    {
        private readonly IDBService _service;

        public Warehouses2Controller(IDBService dBService)
        {
            _service = dBService;
        }

        public IActionResult AddWithProcedure(OrderRequest request)
        {
            

            return Ok(_service.AddWithProcedure(request));
        }
    }
}
