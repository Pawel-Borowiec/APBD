using CW10___Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW10___Kolokwium.Configurations
{
    public class ChampionshipConfiguration : IEntityTypeConfiguration<Championship>
    {
        public void Configure(EntityTypeBuilder<Championship> builder)
        {
            builder.HasKey(key => key.idChampionship);
            builder.Property(x => x.OfficialName).HasMaxLength(100);
            var colection = new List<Championship>
            {
                new Championship
                {
                    idChampionship =1,
                    OfficialName = "euro",
                    Year = 2012
                }
            };
            builder.HasData(colection);
        }

    }
}
