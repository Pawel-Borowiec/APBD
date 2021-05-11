using CW10___Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW10___Kolokwium.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(key => key.IdPlayer);
            builder.Property(x => x.FirstName).HasMaxLength(30);
            builder.Property(x => x.LastName).HasMaxLength(50);

            var players = new List<Player>()
            {
                new Player
                {
                    IdPlayer = 1,
                    FirstName = "Josef",
                    LastName = "Zbaznik",
                    DateOfBirth = Convert.ToDateTime("1997-01-01")
                },
                new Player
                {
                    IdPlayer = 2,
                    FirstName = "Pawlo",
                    LastName = "Karsik",
                    DateOfBirth = Convert.ToDateTime("1999-01-01")
                },
                new Player
                {
                    IdPlayer = 3,
                    FirstName = "Hadol",
                    LastName = "Ajtler",
                    DateOfBirth = Convert.ToDateTime("2007-09-01")
                }
            };
            builder.HasData(players);
        }
    }
}
