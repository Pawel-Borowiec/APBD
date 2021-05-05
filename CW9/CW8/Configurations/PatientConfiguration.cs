using CW8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW8.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(key => key.IdPatient);
            builder.Property(x => x.FirstName).HasMaxLength(100);
            builder.Property(x => x.LastName).HasMaxLength(100);

            var patients = new List<Patient>
            {
                new Patient
                {
                  IdPatient  = 1,
                  FirstName = "Paweł",
                  LastName = "Borowiec",
                  BirthDate = Convert.ToDateTime("1999-11-12")
                },
                new Patient
                {
                    IdPatient  = 2,
                    FirstName = "Paweł",
                    LastName = "Barowiec",
                    BirthDate = Convert.ToDateTime("1997-01-01")
                },
                new Patient
                {
                    IdPatient  = 3,
                    FirstName = "Izajasz",
                    LastName = "Goldberg",
                    BirthDate = Convert.ToDateTime("1995-01-02")
                }
            };

            builder.HasData(patients);
        }
    }
}