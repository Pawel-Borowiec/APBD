using CW7.DTO.Responses;
using CW7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW7.Responses
{
    public class TripResponse
    {
        public int IdTrip { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int MaxPeople { get; set; }

        public List<ClientResponse> Clients { get; set; }

        public List<CountryResponse> Countries { get; set; }


    }
}
