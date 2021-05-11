using CW10___Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW10___Kolokwium.DAL
{
    public interface IDBService
    {
        public Task<IEnumerable<Team>> GetTeamsOnChampionship(int id);
        public int AddPlayerToTeam(Player player, int teamId);
    }
}
