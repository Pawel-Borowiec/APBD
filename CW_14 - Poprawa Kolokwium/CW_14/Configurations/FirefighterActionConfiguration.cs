using CW_14.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_14.Configurations
{
    public class FirefighterActionConfiguration : IEntityTypeConfiguration<Firefighter_Action>
    {
        public void Configure(EntityTypeBuilder<Firefighter_Action> builder)
        {
            builder.HasKey(x => x.IdAction);
            builder.HasKey(x => x.IdFirefighter);
            builder.HasOne(x => x.Firefighter).WithMany(x => x.Firefighter_Actions).HasForeignKey(x => x.IdFirefighter);
            builder.HasOne(x => x.Action).WithMany(x => x.Firefighter_Actions).HasForeignKey(x => x.IdAction);

            var collection = new List<Firefighter_Action>
            {
                new Firefighter_Action
                {
                    IdFirefighter = 1,
                    IdAction = 1
                 
                },
                 new Firefighter_Action
                {
                    IdFirefighter = 2,
                    IdAction = 2

                },
                 new Firefighter_Action
                {
                    IdFirefighter = 3,
                    IdAction = 3

                }
            };

            builder.HasData(collection);
        }
    }
}
