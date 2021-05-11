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
                .WithMany()
                .HasForeignKey(x => x.idPlayer);
            builder
                .HasOne(x => x.Team)
                .WithMany()
                .HasForeignKey(x => x.idTeam);
            builder.Property(x => x.Comment).HasMaxLength(300);
        }
    }
}
