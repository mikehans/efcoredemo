using EFCoreDemo.DataAccess;
using EFCoreDemo.Web.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.Web.Services
{
    public class LeagueService : ILeagueService
    {
        FootballLeagueDbContext _ctx;
        public LeagueService(FootballLeagueDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<int> AddLeague(string name)
        {
            _ctx.Leagues.Add(new Domain.League(){Name=name});
            var recordsModified = await _ctx.SaveChangesAsync();

            return recordsModified;
        }

        public Task DeleteLeague(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.League> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Domain.League>> GetAll()
        {
            return await _ctx.Leagues.ToListAsync();
        }
    }
}
