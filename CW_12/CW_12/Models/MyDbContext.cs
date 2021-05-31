using CW_12.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_12.Models
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

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s18986;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new StudentConfiguration());

        }
    }
}
