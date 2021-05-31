using CW_12.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_12.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.idStudent);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Studies).IsRequired().HasMaxLength(100);
            var students = new List<Student>
            {
                new Student
                {
                    idStudent = 1,
                    FirstName = "Adam",
                    LastName = "Banan",
                    BirthDate = Convert.ToDateTime("2000-05-02"),
                    Studies = "Informatyka"
                },
                new Student
                {
                    idStudent = 2,
                    FirstName = "Paweł",
                    LastName = "Czerniak",
                    BirthDate = Convert.ToDateTime("2001-05-02"),
                    Studies = "Informatyka"
                },
                new Student
                {
                    idStudent = 3,
                    FirstName = "Michał",
                    LastName = "Zachaj",
                    BirthDate = Convert.ToDateTime("2002-05-02"),
                    Studies = "Kulturoznawsto"
                }
            };
        }
    }
}
