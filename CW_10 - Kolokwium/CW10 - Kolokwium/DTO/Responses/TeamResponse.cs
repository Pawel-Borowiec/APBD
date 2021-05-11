using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW10___Kolokwium.DTO.Responses
{
    public class TeamResponse
    {
        public int idTeam { get; set; }
        public string TeamName { get; set; }
        public int MaxAge { get; set; }

        public float Score { get; set; }
    }
}
