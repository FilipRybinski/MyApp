using MyApp.Application.Abstractions;
using MyApp.Core.Repositories;

namespace MyApp.Application.Commands.CloseTeam;

public class CloseTeamHandler : ICommandHandler<CloseTeam>
{
    private readonly ITeamRepository _teamRepository;

    public CloseTeamHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task HandleAsync(CloseTeam command)
    {
        await _teamRepository.CloseTeam(command.Name);
    }
}