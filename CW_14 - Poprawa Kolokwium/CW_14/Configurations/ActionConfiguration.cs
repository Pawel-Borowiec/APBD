using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CW_14.Models;

namespace CW_14.Configurations
{
    public class ActionConfiguration : IEntityTypeConfiguration<Models.Action>
    {
        public void Configure(EntityTypeBuilder<Models.Action> builder)
        {
            builder.HasKey(x => x.IdAction);
            builder.Property(x => x.StartDate).IsRequired();

            var collection = new List< Models.Action >
            {
                new Models.Action
                {
                    IdAction = 1,
                    StartDate = Convert.ToDateTime("2020-01-01"),
                    EndDate = Convert.ToDateTime("2020-04-01"),
                    NeedSpecialEquipment = true
                },
                new  Models.Action
                {
                    IdAction = 2,
                    StartDate = Convert.ToDateTime("2021-01-01"),
                    EndDate = Convert.ToDateTime("2021-04-01"),
                    NeedSpecialEquipment = false
                },
                new  Models.Action
                {
                    IdAction = 3,
                    StartDate = Convert.ToDateTime("2019-01-01"),
                    EndDate = Convert.ToDateTime("2019-04-01"),
                    NeedSpecialEquipment = true
                }
            };

            builder.HasData(collection);
        }
    }
}
