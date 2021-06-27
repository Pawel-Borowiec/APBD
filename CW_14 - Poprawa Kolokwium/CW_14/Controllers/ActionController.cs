using CW_14.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_14.Controllers
{
    [Route("api/actions")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        private readonly IDBService _service;

        public ActionController(IDBService service)
        {
            _service = service;
        }
        [HttpPut("{id}")]
        public IActionResult updateEndDate(int id, DateTime dateTime)
        {
            int result = _service.UpdateEndDateOfAction(id, dateTime);
            if(result == 1)
            {
                return BadRequest("Dana akcja ma już datę zakończenia");
            }else if( result == 2)
            {
                return BadRequest("Data zakończenia nie może być wcześniejsza niż data rozpoczęcia");
            }
            else
            {
                return Ok("Poprawnię dodano datę zakończenia");
            }
        }
        [HttpPost]
        public IActionResult addAction(Models.Action action)
        {
            _service.AddNewAction(action);
            return Ok("Dodano");
        }
    }
}
