using DesafioBNP.Business.Intefaces;
using DesafioBNP.Business.Models;
using DesafioBNP.Business.Models.Validations;

namespace DesafioBNP.Business.Services
{
    public class FootballTeamService : BaseService, IFootballTeamService
    {
        private readonly IFootballTeamRepository _footballTeamRepository;


        public FootballTeamService(IFootballTeamRepository footballTeamRepository, 
                                   INotificator Notificator) : base(Notificator)
        {
            _footballTeamRepository = footballTeamRepository;
        }

        public async Task Add(FootballTeam footballTeam)
        {
            if (!ExecuteValidation(new FootballTeamValidation(), footballTeam)) return;

            await _footballTeamRepository.Add(footballTeam);
        }

        public async Task Update(FootballTeam footballTeam)
        {
            if (!ExecuteValidation(new FootballTeamValidation(), footballTeam)) return;

            await _footballTeamRepository.Update(footballTeam);
        }

        public async Task Remove(Guid id)
        {
            if (_footballTeamRepository.GetFootballTeamPlayers(id).Result.Players.Any())
            {
                Notify("The current team has players registered!");
                return;
            }

            await _footballTeamRepository.Remove(id);
        }

        public void Dispose()
        {
            _footballTeamRepository?.Dispose();
        }
    }
}