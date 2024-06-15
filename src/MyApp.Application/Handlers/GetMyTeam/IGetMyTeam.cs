using MyApp.Core.DTO;

namespace MyApp.Application.Handlers.GetMyTeam;

public interface IGetMyTeam
{
    Task<TeamDto> HandleAsync();
}