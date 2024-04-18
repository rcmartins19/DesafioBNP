using DesafioBNP.Business.Intefaces;
using DesafioBNP.Business.Models;
using DesafioBNP.Business.Models.Validations;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DesafioBNP.Business.Services
{
    public class PlayerService : BaseService, IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;


        public PlayerService(IPlayerRepository playerRepository,
                              INotificator Notificator) : base(Notificator)
        {
            _playerRepository = playerRepository;
        }

        public async Task Add(Player player)
        {
            if (!ExecuteValidation(new PlayerValidation(), player)) return;

            var registeredPlayers = await _playerRepository.GetPlayersByTeam(player.TeamId);

            if (registeredPlayers.ToList().Exists(x => x.ShirtNumber == player.ShirtNumber))
            {
                Notify(string.Format("There is already a player registered with shirt number {0} for this team!" +
                                     "Please choose another number.", player.ShirtNumber.ToString()));
                return;
            }
            
            await _playerRepository.Add(player);
        }

        public async Task Update(Player player)
        {
            if (!ExecuteValidation(new PlayerValidation(), player)) return;

            var registeredPlayers = await _playerRepository.GetAll();

            if (registeredPlayers.Exists(x => x.ShirtNumber == player.ShirtNumber && x.TeamId == player.TeamId))
            {
                Notify(string.Format("There is already a player registered with shirt number {0} for this team! " +
                                     "Please choose another number.", player.ShirtNumber.ToString()));
                return;
            }

            await _playerRepository.Update(player);
        }

        public async Task Remove(Guid id)
        {
            await _playerRepository.Remove(id);
        }

        public void Dispose()
        {
            _playerRepository?.Dispose();
        }
    }
}