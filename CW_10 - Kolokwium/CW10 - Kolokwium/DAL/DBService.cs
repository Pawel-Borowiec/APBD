using CW10___Kolokwium.DTO.Responses;
using CW10___Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW10___Kolokwium.DAL
{
    public class DBService : IDBService
    {
        private readonly TestDbContext _context;
        public DBService()
        {
            _context = new TestDbContext();
        }

        public int AddPlayerToTeam(Player player, int teamId)
        {
            if (!_context.Players.Contains(player))
            {
                return 2;
            }
            var team = _context.Teams.Where(x => x.idTeam == teamId).FirstOrDefault();
            if (2021 - player.DateOfBirth.Year > team.MaxAge)
            {
                return 3;
            }
            var playerTeamCount = _context.PlayerTeams
                .Where(x => x.idTeam == teamId)
                .Where(x => x.idPlayer == player.IdPlayer)
                .Count();
            if (playerTeamCount != 0)
            {
                return 4;
            }
            PlayerTeam result = new PlayerTeam();
            result.idPlayerTeam = _context.PlayerTeams.Count() + 1;
            result.idPlayer = player.IdPlayer;
            result.idTeam = teamId;
            _context.PlayerTeams.Add(result);
            return 1;
        }

        public Task<IEnumerable<Team>> GetTeamsOnChampionship(int id)
        {
            var temp = _context.championship_Teams.Where(x => x.idChampionship == id).Select( n => new { n.idTeam, n.Score });
            var temp2 = _context.Teams.Where(x => temp.Any(y => y.idTeam == x.idTeam)).ToList();
            IEnumerable<TeamResponse> response = new List<TeamResponse>();
            foreach( Team x in temp2)
            {
                TeamResponse temp3 = new TeamResponse();
                temp3.idTeam = x.idTeam;
                temp3.MaxAge = x.MaxAge;
                temp3.TeamName = x.TeamName;
            }


            return (Task<IEnumerable<Team>>)response;
            
        }
    }
}
