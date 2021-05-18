using CW8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW8.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserId);
         //   builder.Property(x => x.UserId).ValueGeneratedOnAdd();
            builder.Property(x => x.Login).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(100);

            var users = new List<User>
            {
                new User
                {
                    UserId = 1,
                    Login = "admin",
                    Password = "admin"
                },
                new User
                {
                    UserId = 2,
                    Login = "staszekpl",
                    Password ="polska123"
                },
                new User
                {
                    UserId = 3,
                    Login = "maksous",
                    Password = "maksous"
                }
            };
            builder.HasData(users);
        }
    }
}
