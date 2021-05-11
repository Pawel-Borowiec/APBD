using CW10___Kolokwium.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW10___Kolokwium.Models
{
    public class TestDbContext : DbContext
    {
        public TestDbContext()
        {

        }

        public TestDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Player> Players{ get; set; }
        public DbSet<PlayerTeam> PlayerTeams{ get; set; }
        public DbSet<Team> Teams{ get; set; }
        public DbSet<Championship> Championships { get; set; }
        public DbSet<Championship_Team> championship_Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s18986;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerTeamConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new Championship_TeamConfiguration());
            modelBuilder.ApplyConfiguration(new ChampionshipConfiguration());

        }
    }
}
