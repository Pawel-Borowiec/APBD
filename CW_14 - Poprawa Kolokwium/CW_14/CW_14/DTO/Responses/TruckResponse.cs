using CW_14.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_14.DTO.Responses
{

    public class TruckResponse
    {
        public FireTruck FireTruck { get; set; }
        public List<ActionResponse> ActionsResponses { get; set; }
    }
}
