using DesafioBNP.Business.Models;

namespace DesafioBNP.Business.Intefaces
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Task<IEnumerable<Player>> GetPlayersByTeam(Guid teamId);
        Task<IEnumerable<Player>> GetAllPlayers();
        Task<Player> GetPlayer(Guid id);
    }
}