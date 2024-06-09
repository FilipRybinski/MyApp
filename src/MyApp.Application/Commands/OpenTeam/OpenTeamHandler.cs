using MyApp.Application.Abstractions;

namespace MyApp.Application.Commands.OpenTeam;

public class OpenTeamHandler : ICommandHandler<OpenTeam>
{
    public Task HandleAsync(OpenTeam command)
    {
        throw new NotImplementedException();
    }
}