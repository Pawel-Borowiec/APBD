using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW10___Kolokwium.Models
{
    public class Championship_Team
    {
        public int idChampionshipTeam { get; set; }
        public int idTeam { get; set; }
        public int idChampionship { get; set; }
        public float Score { get; set; }
        public virtual Team Team { get; set; }
        public virtual Championship Championship { get; set; }

    }
}
