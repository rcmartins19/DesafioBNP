using AutoMapper;
using DesafioBNP.Api.Dtos;
using DesafioBNP.Business.Intefaces;
using DesafioBNP.Business.Models;
using DesafioBNP.Business.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBNP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : MainController
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;

        public PlayersController(INotificator notificator,
                                  IPlayerRepository playerRepository,
                                  IPlayerService playerService,
                                  IMapper mapper) : base(notificator)

        {
            _playerRepository = playerRepository;
            _playerService = playerService;
            _mapper = mapper;
        }

        //GET ALL
        [HttpGet]
        public async Task<IEnumerable<PlayerDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<PlayerDto>>(await _playerRepository.GetAllPlayers());
        }
        

        //GET BY ID
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PlayerDto>> GetById(Guid id)
        {
            var playerDto = await GetPlayer(id);

            if (playerDto == null) return NotFound();

            return playerDto;
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<PlayerDto>> Add(PlayerDto playerDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _playerService.Add(_mapper.Map<Player>(playerDto));

            return CustomResponse(playerDto);
        }

        //PUT
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, PlayerDto playerDto)
        {
            if (id != playerDto.Id)
            {
                NotifyError("Players Ids do not match!");
                return CustomResponse();
            }

            var playerUpdate = await GetPlayer(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            playerUpdate.TeamId = playerDto.TeamId;
            playerUpdate.Name = playerDto.Name;
            playerUpdate.Age = playerDto.Age;
            playerUpdate.ShirtNumber = playerDto.ShirtNumber;
            playerUpdate.Active = playerDto.Active;

            await _playerService.Update(_mapper.Map<Player>(playerUpdate));

            return CustomResponse(playerDto);
        }

        //DELETE
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<PlayerDto>> Remove(Guid id)
        {
            var player = await GetPlayer(id);

            if (player == null) return NotFound();

            await _playerService.Remove(id);

            return CustomResponse(player);
        }


        #region Private methods

        private async Task<PlayerDto> GetPlayer(Guid id)
        {
            return _mapper.Map<PlayerDto>(await _playerRepository.GetPlayer(id));
        }

        #endregion
    }
}
