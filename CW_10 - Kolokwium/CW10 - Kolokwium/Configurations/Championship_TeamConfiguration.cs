using CW10___Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW10___Kolokwium.Configurations
{
    public class Championship_TeamConfiguration : IEntityTypeConfiguration<Championship_Team>
    {
        public void Configure(EntityTypeBuilder<Championship_Team> builder)
        {
            builder.HasKey(key => key.idChampionshipTeam);
            builder
                .HasOne(x => x.Team)
                .WithMany()
                .HasForeignKey(x => x.idTeam);
            builder
                .HasOne(x => x.Championship)
                .WithMany()
                .HasForeignKey(x => x.idChampionship);
        }
    }
}
