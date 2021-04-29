using CW8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW8.Configurations
{
    public class MedicamentConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(key => key.IdMedicament);
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.Property(x => x.Type).HasMaxLength(100);

            var medicaments = new List<Medicament>()
            {
                new Medicament
                {
                    IdMedicament = 1,
                    Name = "Domestos",
                    Description = "Na chore gardło",
                    Type = "Doustny"
                },
                new Medicament
                {
                    IdMedicament = 2,
                    Name = "Avimarin",
                    Description = "A na twartość",
                    Type = "Dodupny"
                },
                new Medicament
                {
                    IdMedicament = 3,
                    Name = "Stoperan",
                    Description = "Na wszystko",
                    Type = "Doustny"
                }
            };

            builder.HasData(medicaments);
        }
    }
}