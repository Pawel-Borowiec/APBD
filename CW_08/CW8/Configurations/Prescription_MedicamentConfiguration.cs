using CW8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace CW8.Configurations
{
    public class Prescription_MedicamentConfiguration : IEntityTypeConfiguration<Prescription_Medicament>
    {
        public void Configure(EntityTypeBuilder<Prescription_Medicament> builder)
        {
            builder.HasKey(key => new { key.IdMedicament, key.IdPrescription });
            builder
                .HasOne(x => x.Prescription)
                .WithMany(y => y.Prescription_Medicaments)
                .HasForeignKey(x => x.IdPrescription);
            builder
                .HasOne(x => x.Medicament)
                .WithMany(y => y.Prescription_Medicaments)
                .HasForeignKey(x => x.IdMedicament);
            builder.Property(x => x.Dose).IsRequired();
            builder.Property(x => x.Details).HasMaxLength(100);

            var prescriptionMedicaments = new List<Prescription_Medicament>
            {
                new Prescription_Medicament
                {
                    IdMedicament = 1,
                    IdPrescription = 1,
                    Dose = 2,
                    Details = "Podwójna dawka"
                },
                new Prescription_Medicament
                {
                    IdMedicament = 2,
                    IdPrescription = 2,
                    Dose = 2,
                    Details = "Podwójna dawka"
                },
                new Prescription_Medicament
                {
                    IdMedicament = 3,
                    IdPrescription = 3,
                    Dose = 3,
                    Details = "Potrójna dawka"
                }
            };

            builder.HasData(prescriptionMedicaments);
        }
    }
}