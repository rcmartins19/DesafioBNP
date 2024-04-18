using DesafioBNP.Business.Models;

namespace DesafioBNP.Business.Intefaces
{
    public interface IFootballTeamService : IDisposable
    {
        Task Add(FootballTeam team);
        Task Update(FootballTeam team);
        Task Remove(Guid id);

    }
}