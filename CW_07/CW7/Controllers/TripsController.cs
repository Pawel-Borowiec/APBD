using CW7.DTO.Responses;
using CW7.Models;
using CW7.Requests;
using CW7.Responses;
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
    [Route("api/trips")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly IDbService _service;

        public TripsController(IDbService Dbservice)
        {
            _service = Dbservice;
        }

        [HttpGet]
        public IActionResult GetTrips()
        {     
        return Ok(_service.GetSortedTrips());
        }
        [HttpPost("{idTrip}/clients")]
        public IActionResult AddClientToTrip(AddClientToTripRequest request, int idTrip)
        {
            int result = _service.AddClientToTrip(request, idTrip);
            if (result == 2)
            {
                return StatusCode(400, "Wycieczka o podanym id nie istnieje");
            }else if(result == 1)
            {
                return StatusCode(400, "Klient jest już zapisany na podaną wycieczke");
            }
            else
            {
                return Ok("Przypisano klienta do podanej wycieczki");
            }
            
        }
    }
}
