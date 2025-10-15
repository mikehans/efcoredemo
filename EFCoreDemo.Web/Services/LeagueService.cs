using EFCoreDemo.Web.Contracts;

namespace EFCoreDemo.Web.Services
{
    public class LeagueService : ILeagueService
    {
        public LeagueService()
        {
            
        }
        public Task AddLeague(string name)
        {
            throw new NotImplementedException();
        }

        public Task DeleteLeague(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.League> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.League>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
