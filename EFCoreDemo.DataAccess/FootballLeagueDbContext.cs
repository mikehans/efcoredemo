using EFCoreDemo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemo.DataAccess
{
    public class FootballLeagueDbContext :DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<League> Leagues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: Move config string to appsettings
            // TODO: Replace LogTo with Serilog
            // TODO: What's the diff to logging without Sensitive Data Logging vs with it?
            optionsBuilder
                .UseNpgsql("User ID=postgres;Password=myPassword;Host=localhost;Port=5432;Database=football_league;")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("demo");
        }
    }
}
