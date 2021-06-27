using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_14.Models
{
    public class Firefighter_Action
    {
        public int IdFirefighter { get; set; }
        public virtual Firefighter Firefighter { get; set; }
        public int IdAction { get; set; }
        public virtual Action Action { get; set; }
    }
}
