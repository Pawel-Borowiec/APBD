using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_14.Models
{
    public class Firefighter
    {
        public int IdFirefigther { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Firefighter_Action> Firefighter_Actions { get; set; }
    }
}
