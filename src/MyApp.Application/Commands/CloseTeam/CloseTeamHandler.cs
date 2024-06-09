using MyApp.Application.Abstractions;

namespace MyApp.Application.Commands.CloseTeam;

public class CloseTeamHandler : ICommandHandler<CloseTeam>
{
    public Task HandleAsync(CloseTeam command)
    {
        throw new NotImplementedException();
    }
}