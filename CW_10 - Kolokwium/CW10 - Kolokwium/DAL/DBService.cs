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

        public IEnumerable<Player> getPlayers()
        {
            return _context.Players.ToList();
        }

        public IEnumerable<Team> GetTeams()
        {
            return _context.Teams.ToList();
        }

        public IEnumerable<object> GetTeamsOnChampionship(int id)
        {
            var result = _context.championship_Teams
                .Include(x => x.Team)
                .Where(x => x.idChampionship==id)
                .Select(x => new {idTeam = x.Team.idTeam, TeamName = x.Team.TeamName, MaxAge = x.Team.MaxAge, Score = x.Score  })
                .OrderByDescending(x => x.Score)
                .ToList();
            return result;
        }
    }
}
