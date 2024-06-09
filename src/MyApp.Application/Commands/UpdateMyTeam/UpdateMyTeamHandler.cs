using MyApp.Application.Abstractions;
using MyApp.Core.Repositories;

namespace MyApp.Application.Commands.UpdateMyTeam;

public class UpdateMyTeamHandler : ICommandHandler<UpdateMyTeam>
{
    private readonly ITeamRepository _teamRepository;

    public UpdateMyTeamHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task HandleAsync(UpdateMyTeam command)
    {
        await _teamRepository.UpdateMyTeam(command.Name);
    }
}