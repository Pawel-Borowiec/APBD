using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_14.Models
{
    public class Action
    {
        public int IdAction { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool NeedSpecialEquipment { get; set; }
        public virtual ICollection<Firefighter_Action> Firefighter_Actions { get; set; }
        public virtual ICollection<FireTruck_Action> FireTruck_Actions { get; set; }
    }
}
