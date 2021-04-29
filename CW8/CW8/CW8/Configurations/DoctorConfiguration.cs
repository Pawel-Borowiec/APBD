using CW8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW8.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(key => key.IdDoctor);
            builder.Property(x => x.FirstName).HasMaxLength(100);
            builder.Property(x => x.LastName).HasMaxLength(100);
            builder.Property(x => x.Email).HasMaxLength(100);

            var doctors = new List<Doctor>
            {
                new Doctor
                {
                    IdDoctor = 1,
                    FirstName = "Josef",
                    LastName = "Zbaznik",
                    Email = "josef.zbaznik@gmail.com"
                },
                new Doctor
                {
                    IdDoctor = 2,
                    FirstName = "Rafał",
                    LastName = "Karaś",
                    Email = "rafal.karas@gmail.com"
                },
                new Doctor
                {
                    IdDoctor = 3,
                    FirstName = "Anrzej",
                    LastName = "Pracnik",
                    Email = "Anrzej.pracnik@gmail.com"
                }
            };

            builder.HasData(doctors);
        }
    }
}