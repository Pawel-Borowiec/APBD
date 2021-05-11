using CW10___Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW10___Kolokwium.Configurations
{
    public class PlayerTeamConfiguration : IEntityTypeConfiguration<PlayerTeam>
    {
        public void Configure(EntityTypeBuilder<PlayerTeam> builder)
        {
            builder.HasKey(key => key.idPlayerTeam);
            builder
                .HasOne(x => x.Player)
                .WithMany(y => y.PlayerTeams)
                .HasForeignKey(x => x.idPlayer);
            builder
                .HasOne(x => x.Team)
                .WithMany(y => y.PlayerTeams)
                .HasForeignKey(x => x.idTeam);
            builder.Property(x => x.Comment).HasMaxLength(300);

            var colection = new List<PlayerTeam>
            {
                new PlayerTeam
                {
                    idPlayerTeam = 1,
                    idPlayer =1,
                    idTeam =1
                },
                new PlayerTeam
                {
                    idPlayerTeam = 2,
                    idPlayer =2,
                    idTeam =1
                },
                new PlayerTeam
                {
                    idPlayerTeam = 3,
                    idPlayer =3,
                    idTeam =1
                }
            };
            builder.HasData(colection);
        }
    }
}
