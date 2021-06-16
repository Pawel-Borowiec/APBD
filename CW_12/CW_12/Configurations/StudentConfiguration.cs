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
                    Studies = "Informatyka",
                    Avatar = "https://cdn.icon-icons.com/icons2/2643/PNG/512/male_boy_person_people_avatar_icon_159358.png"
                },
                new Student
                {
                    idStudent = 2,
                    FirstName = "Paweł",
                    LastName = "Czerniak",
                    BirthDate = Convert.ToDateTime("2001-05-02"),
                    Studies = "Informatyka",
                    Avatar = "https://cdn.icon-icons.com/icons2/2643/PNG/512/male_boy_person_people_avatar_icon_159358.png"
                },
                new Student
                {
                    idStudent = 3,
                    FirstName = "Natalia",
                    LastName = "Zachaj",
                    BirthDate = Convert.ToDateTime("2002-05-02"),
                    Studies = "Kulturoznawsto",
                    Avatar = "https://image.flaticon.com/icons/png/512/194/194938.png"
                },
                new Student
                {
                    idStudent = 4,
                    FirstName = "Rudolf",
                    LastName = "Stronheim",
                    BirthDate = Convert.ToDateTime("2001-02-22"),
                    Studies = "Germanistyka",
                    Avatar = "https://cdn.icon-icons.com/icons2/2643/PNG/512/male_boy_person_people_avatar_icon_159358.png"
                },
                new Student
                {
                    idStudent = 5,
                    FirstName = "Monika",
                    LastName = "Kurczyk",
                    BirthDate = Convert.ToDateTime("2004-05-12"),
                    Studies = "Kulturoznawsto",
                    Avatar = "https://image.flaticon.com/icons/png/512/194/194938.png"
                },
                new Student
                {
                    idStudent = 6,
                    FirstName = "Michał",
                    LastName = "Parchaś",
                    BirthDate = Convert.ToDateTime("2002-05-02"),
                    Studies = "Kulturoznawsto",
                    Avatar = "https://cdn.icon-icons.com/icons2/2643/PNG/512/male_boy_person_people_avatar_icon_159358.png"
                },
                new Student
                {
                    idStudent = 7,
                    FirstName = "Michał",
                    LastName = "Zachajewczyk",
                    BirthDate = Convert.ToDateTime("2002-07-06"),
                    Studies = "Obrona narodowa",
                    Avatar = "https://cdn.icon-icons.com/icons2/2643/PNG/512/male_boy_person_people_avatar_icon_159358.png"
                },
                new Student
                {
                    idStudent = 8,
                    FirstName = "Tytus",
                    LastName = "Bomba",
                    BirthDate = Convert.ToDateTime("1998-05-02"),
                    Studies = "Obrona narodowa",
                    Avatar = "https://cdn.icon-icons.com/icons2/2643/PNG/512/male_boy_person_people_avatar_icon_159358.png"
                }
        };
            builder.HasData(students);
        }
    }
}
