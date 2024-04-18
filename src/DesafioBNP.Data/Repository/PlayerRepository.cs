using DesafioBNP.Business.Intefaces;
using DesafioBNP.Business.Models;
using DesafioBNP.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioBNP.Data.Repository
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(MyDbContext context) : base(context) { }

        public async Task<Player> GetPlayer(Guid id)
        {
            return await Db.Players.AsNoTracking().Include(f => f.FootballTeam)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            return await Db.Players.AsNoTracking().Include(f => f.FootballTeam)
                .OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<IEnumerable<Player>> GetPlayersByTeam(Guid teamId)
        {
            return await Search(p => p.TeamId == teamId);
        }
    }
}