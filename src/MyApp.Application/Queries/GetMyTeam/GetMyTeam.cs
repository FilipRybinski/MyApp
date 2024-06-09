using MyApp.Application.Abstractions;
using MyApp.Application.DTO;

namespace MyApp.Application.Queries.GetMyTeam;

public record GetMyTeam : IQuery<TeamDto>;