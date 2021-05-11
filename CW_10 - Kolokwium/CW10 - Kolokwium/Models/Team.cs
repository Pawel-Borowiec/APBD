using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW10___Kolokwium.Models
{
    public class Team
    {
        public int idTeam { get; set; }
        public string TeamName { get; set; }
        public int MaxAge { get; set; }
        public virtual ICollection<PlayerTeam> PlayerTeams { get; set; } = new HashSet<PlayerTeam>();
        public virtual ICollection<Championship_Team> Championship_Teams { get; set; } = new HashSet<Championship_Team>();


    }
}
