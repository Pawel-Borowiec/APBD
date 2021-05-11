using CW10___Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW10___Kolokwium.DAL
{
    public interface IDBService
    {
        public IEnumerable<object> GetTeamsOnChampionship(int id);
        public int AddPlayerToTeam(Player player, int teamId);
        public IEnumerable<Player> getPlayers();

        public IEnumerable<Team> GetTeams();
    }
}
