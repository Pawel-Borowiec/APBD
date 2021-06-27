using CW_14.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_14.Configurations
{
    public class FirefighterConfiguration : IEntityTypeConfiguration<Firefighter>
    {
        public void Configure(EntityTypeBuilder<Firefighter> builder)
        {
            builder.HasKey(key => key.IdFirefigther);
            builder.Property(x => x.FirstName).HasMaxLength(30);
            builder.Property(x => x.LastName).HasMaxLength(50);

            var collection = new List<Firefighter>
            {
                new Firefighter
                {
                    IdFirefigther =1,
                    FirstName = "John",
                    LastName = "Doe"
                },
                new Firefighter
                {
                    IdFirefigther =2,
                    FirstName = "Greg",
                    LastName = "Hans"
                },
                new Firefighter
                {
                    IdFirefigther =3,
                    FirstName = "Joe",
                    LastName = "Zonk"
                }
            };

            builder.HasData(collection);
        }
    }
}
