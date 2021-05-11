using CW10___Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW10___Kolokwium.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(key => key.idTeam);
            builder.Property(x => x.TeamName).HasMaxLength(30);
            var teams = new List<Team>
            {
                new Team
                {
                    idTeam = 1,
                    MaxAge = 18,
                    TeamName = "Legia"
                },
                new Team
                {
                    idTeam = 2,
                    MaxAge = 20,
                    TeamName = "Lech"
                },
                new Team
                {
                    idTeam = 3,
                    MaxAge = 16,
                    TeamName = "Wisła"
                }
            };
            builder.HasData(teams);
        }

    }
}
