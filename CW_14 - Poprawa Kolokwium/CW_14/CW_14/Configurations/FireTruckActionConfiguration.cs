using CW_14.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_14.Configurations
{
    public class FireTruckActionConfiguration : IEntityTypeConfiguration<FireTruck_Action>
    {
        public void Configure(EntityTypeBuilder<FireTruck_Action> builder)
        {
            builder.HasKey(x => x.IdFireTruck_Action);
            builder.HasOne(x => x.FireTruck).WithMany(x => x.FireTruck_Actions).HasForeignKey(x => x.IdFireTruck);
            builder.HasOne(x => x.Action).WithMany(x => x.FireTruck_Actions).HasForeignKey(x => x.IdAction);

            var collection = new List<FireTruck_Action>
            {
                new FireTruck_Action
                {
                    IdFireTruck_Action = 1,
                    IdFireTruck = 1,
                    IdAction = 1,
                    AssigmentTime = Convert.ToDateTime("2021-02-01")
                },
                new FireTruck_Action
                {
                    IdFireTruck_Action = 2,
                    IdFireTruck = 1,
                    IdAction = 2,
                    AssigmentTime = Convert.ToDateTime("2021-07-01")
                },
                new FireTruck_Action
                {
                    IdFireTruck_Action = 3,
                    IdFireTruck = 3,
                    IdAction = 1,
                    AssigmentTime = Convert.ToDateTime("2021-09-01")
                }
            };

            builder.HasData(collection);
        }
    }
}
