using AutoMapper;
using MyApp.Application.DTO;
using MyApp.Core.Entities;

namespace MyApp.Application.Mapper.TeamMap;

internal class TeamProfile : Profile
{
    public TeamProfile()
    {
        CreateMap<Team, TeamDto>();
    }
}