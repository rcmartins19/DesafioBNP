using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DesafioBNP.Api.Dtos;
using DesafioBNP.Api.Controllers;
using AutoMapper;
using DesafioBNP.Business.Intefaces;
using DesafioBNP.Business.Notifications;
using Microsoft.AspNetCore.Authorization;
using DesafioBNP.Business.Models;

namespace DesafioBNP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballTeamsController : MainController
    {
        private readonly IFootballTeamRepository _teamRepository;
        private readonly IFootballTeamService _teamService;
        private readonly IMapper _mapper;

        public FootballTeamsController(IFootballTeamRepository teamRepository,
                                       IFootballTeamService teamService,
                                       IMapper mapper,
                                       INotificator notificator) : base (notificator)
        {
            _teamRepository = teamRepository;
            _teamService = teamService;
            _mapper = mapper;
        }

        //GET ALL
        [HttpGet]
        public async Task<IEnumerable<FootballTeamDto>> GetFootballTeams()
        {
            return _mapper.Map<IEnumerable<FootballTeamDto>>(await _teamRepository.GetAll());
        }

        //GET BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<FootballTeamDto>> GetFootballTeam(Guid id)
        {
            var team = await GetFootballTeamPlayers(id);
            
            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        //PUT
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<FootballTeamDto>> Atualizar(Guid id, FootballTeamDto footballTeamDto)
        {
            if (id != footballTeamDto.Id)
            {
                NotifyError("Teams Ids do not match!");
                return CustomResponse(footballTeamDto);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _teamService.Update(_mapper.Map<FootballTeam>(footballTeamDto));

            return CustomResponse(footballTeamDto);
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<FootballTeamDto>> Add(FootballTeamDto footballTeamDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _teamService.Add(_mapper.Map<FootballTeam>(footballTeamDto));

            return CustomResponse(footballTeamDto);
        }

        //DELETE
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<FootballTeamDto>> Remove(Guid id)
        {
            var footballTeam = await GetTeam(id);

            if (footballTeam == null) return NotFound();

            await _teamService.Remove(id);

            return CustomResponse(footballTeam);
        }


        #region Private methods

        private async Task<FootballTeamDto> GetFootballTeamPlayers(Guid id)
        {
            return _mapper.Map<FootballTeamDto>(await _teamRepository.GetFootballTeamPlayers(id));
        }

        private async Task<FootballTeamDto> GetTeam(Guid id)
        {
            return _mapper.Map<FootballTeamDto>(await _teamRepository.GetById(id));
        }

        #endregion
    }
}
