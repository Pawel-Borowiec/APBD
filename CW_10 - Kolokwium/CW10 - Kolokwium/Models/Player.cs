using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW10___Kolokwium.Models
{
    public class Player
    {
        public int IdPlayer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual ICollection<PlayerTeam> PlayerTeams { get; set; } = new HashSet<PlayerTeam>();
    }
}
