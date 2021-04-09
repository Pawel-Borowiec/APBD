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
    [Route("api/warehouses")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {

        private readonly IDBService _service;

        public WarehousesController(IDBService dBService)
        {
            _service = dBService;
        }
         
        [HttpGet]
        public IActionResult GetAllOWarehouses()
        {
            return Ok(_service.getAllWarehouses());
        }
        [HttpPost]
        public IActionResult AddOrder(OrderRequest request)
        {
            switch (_service.AddProducts(request))
            {
                case 1:
                    return Ok("Udana próba");
                case 2:
                    return StatusCode(400, "Product/Hurtowania o podanym id nie istnieje");
                case 3:
                    return StatusCode(400, "Nie ma odpowiedniego zlecenia");
                default:
                    return BadRequest("Nieznany problem");
            }
        }
    }
}
