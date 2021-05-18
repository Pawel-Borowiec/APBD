

using CW8.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CW8.Models
{
    public class MyDbContext : DbContext
    {

        public MyDbContext()
        {
                
        }

        public MyDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s18986;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new PrescriptionConfiguration());
            modelBuilder.ApplyConfiguration(new MedicamentConfiguration());
            modelBuilder.ApplyConfiguration(new Prescription_MedicamentConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

        }
    }
}
