using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW10___Kolokwium.Models
{
    public class Championship
    {
        public int idChampionship { get; set; }
        public string OfficialName { get; set; }
        public int Year { get; set; }

        public virtual ICollection<Championship_Team> Championship_Teams { get; set; } = new HashSet<Championship_Team>();

    }
}
