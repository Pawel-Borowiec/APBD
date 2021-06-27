using CW_14.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_14.Models
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

        public DbSet<Firefighter> Firefighters { get; set; }
        public DbSet<Firefighter_Action> Firefighter_Actions { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<FireTruck_Action> FireTruck_Actions { get; set; }
        public DbSet<FireTruck> FireTrucks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s18986;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ActionConfiguration());
            modelBuilder.ApplyConfiguration(new FirefighterConfiguration());
            modelBuilder.ApplyConfiguration(new FirefighterActionConfiguration());
            modelBuilder.ApplyConfiguration(new FireTruckConfiguration());
            modelBuilder.ApplyConfiguration(new FireTruckActionConfiguration());

        }
    }
}
