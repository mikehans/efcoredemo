using EFCoreDemo.Domain;

namespace EFCoreDemo.Web.Contracts
{
    public interface ILeagueService
    {
        Task AddLeague(string name);
        Task DeleteLeague(int id);
        Task<List<EFCoreDemo.Domain.League>> GetAll();
        Task<EFCoreDemo.Domain.League> Get(int id);
    }
}
