using CW_14.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_14.Configurations
{
    public class FireTruckConfiguration : IEntityTypeConfiguration<FireTruck>
    {
        public void Configure(EntityTypeBuilder<FireTruck> builder)
        {
            builder.HasKey(x => x.IdFireTruck);
            builder.Property(x => x.OperationalNumber).HasMaxLength(10);

            var collection = new List<FireTruck>
            {
                new FireTruck
                {
                    IdFireTruck = 1,
                    OperationalNumber = "213545f",
                    SpecialEquipment = true
                },
                new FireTruck
                {
                    IdFireTruck = 2,
                    OperationalNumber = "POLONIA",
                    SpecialEquipment = true
                },
                new FireTruck
                {
                    IdFireTruck = 3,
                    OperationalNumber = "LGBTNKWD",
                    SpecialEquipment = false
                }
            };

            builder.HasData(collection);
        }
    }
}
