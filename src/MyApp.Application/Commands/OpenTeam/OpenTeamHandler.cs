using MyApp.Application.Abstractions;
using MyApp.Core.Entities;
using MyApp.Core.Repositories;

namespace MyApp.Application.Commands.OpenTeam;

public class OpenTeamHandler : ICommandHandler<OpenTeam>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IUserRepository _userRepository;

    public OpenTeamHandler(IUserRepository userRepository, ITeamRepository teamRepository)
    {
        _userRepository = userRepository;
        _teamRepository = teamRepository;
    }

    public async Task HandleAsync(OpenTeam command)
    {
        var user = await _userRepository.GetCurrentUser();
        if (user.TeamId is not null)
        {
            throw new Exception();
        }

        var team = new Team(command.Name, user.Id);
        _teamRepository.OpenTeam(team);
    }
}