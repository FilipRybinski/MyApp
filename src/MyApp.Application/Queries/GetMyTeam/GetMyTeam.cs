using MyApp.Application.Abstractions;
using MyApp.Core.DTO;

namespace MyApp.Application.Queries.GetMyTeam;

public record GetMyTeam(Guid Id) : IQuery<TeamDto>;