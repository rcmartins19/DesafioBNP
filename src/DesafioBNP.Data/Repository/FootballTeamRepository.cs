using DesafioBNP.Business.Intefaces;
using DesafioBNP.Business.Models;
using DesafioBNP.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioBNP.Data.Repository
{
    public class FootballTeamRepository : Repository<FootballTeam>, IFootballTeamRepository
    {
        public FootballTeamRepository(MyDbContext context) : base(context)
        {
        }

        public async Task<FootballTeam> GetFootballTeamPlayers(Guid id)
        {
            return await Db.FootballTeams.AsNoTracking()
                .Include(c => c.Players)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}