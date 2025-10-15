using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFCoreDemo.DataAccess
{
    public class FootballLeagueDbContextFactory : IDesignTimeDbContextFactory<FootballLeagueDbContext>
    {
        public FootballLeagueDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<FootballLeagueDbContext> optionsBuilder = new();

            optionsBuilder.UseNpgsql("User ID=postgres;Password=myPassword;Host=localhost;Port=5432;Database=football_league;");

            return new FootballLeagueDbContext(optionsBuilder.Options);
        }
    }
}
