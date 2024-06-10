using MyApp.Core.Entities;

namespace MyApp.Core.Repositories;

public interface ITeamRepository
{
    Task<Team> GetMyTeam(Guid id);
    Task OpenTeam(Team team);
    Task CloseTeam(string name);
    Task UpdateMyTeam(string name);
    Task<bool> IsTeamAlreadyCreated(Guid userId);
}