using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_14.Models
{
    public class FireTruck_Action
    { 
    
        public int IdFireTruck_Action { get; set; }
        public DateTime AssigmentTime { get; set; }
        public int IdFireTruck { get; set; }
        public virtual FireTruck FireTruck { get; set; }
        public int IdAction { get; set; }
        public virtual Action Action { get; set; }

    }
}
