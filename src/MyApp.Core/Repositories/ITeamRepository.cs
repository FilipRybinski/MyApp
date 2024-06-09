using MyApp.Core.Entities;

namespace MyApp.Core.Repositories;

public interface ITeamRepository
{
    Task OpenTeam(Team team);
    Task CloseTeam(string name);
}