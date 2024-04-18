using DesafioBNP.Business.Models;

namespace DesafioBNP.Business.Intefaces
{
    public interface IFootballTeamRepository : IRepository<FootballTeam>
    {
        Task<FootballTeam> GetFootballTeamPlayers(Guid id);
    }
}