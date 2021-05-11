using CW4.Models;
using CW4.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CW4.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private IDBService _dBService;

        public AnimalsController(IDBService dBService)
        {
            _dBService = dBService;
        }

        [HttpGet]
        public IActionResult GetAnimals(string orderBy = "name")
        {

            IEnumerable<Animal> list = _dBService.GetAnimals(orderBy);
            return Ok(list);
        }

        [HttpPost]
        public IActionResult AddAnimal(Animal animal)
        {
            _dBService.AddAnimal(animal);
            return Ok(animal);
        }

        [HttpPut("{ID}")]
        public IActionResult UpdateAnimal(Animal animal, int Id)
        {
            _dBService.UpdateAnimal(animal, Id);
            return Ok(animal);
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteAnimal(int Id)
        {
            _dBService.DeleteAnimal(Id);
            return Ok("Usunięto poprawnie");
        }
    }
}
