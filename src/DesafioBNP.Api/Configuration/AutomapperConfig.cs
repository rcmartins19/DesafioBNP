using AutoMapper;
using DesafioBNP.Api.Dtos;
using DesafioBNP.Business.Models;

namespace DesafioBNP.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<FootballTeam, FootballTeamDto>().ReverseMap();

            CreateMap<PlayerDto, Player>();
                 
            CreateMap<Player, PlayerDto>()
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.FootballTeam.TeamName));
        }
    }
}