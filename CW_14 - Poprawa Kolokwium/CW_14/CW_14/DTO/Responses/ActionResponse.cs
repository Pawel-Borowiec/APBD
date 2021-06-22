using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_14.DTO.Responses
{
    public class ActionResponse
    {
        public Models.Action Action { get; set; }
        public int numberOdFirefighters { get; set; }
        
        public DateTime AssigmentDate { get; set; }
    }
}
