using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW10___Kolokwium.Models
{
    public class PlayerTeam
    {
        public int idPlayerTeam { get; set; }
        public int idPlayer { get; set; }
        public int idTeam { get; set; }
        public int NumOnShirt { get; set; }
        public string? Comment { get; set; }
        public virtual Player Player { get; set; }
        public virtual Team Team { get; set; }

    }
}
