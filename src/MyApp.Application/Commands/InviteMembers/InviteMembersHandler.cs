using MyApp.Application.Abstractions;

namespace MyApp.Application.Commands.AddMembers;

public class InviteMembersHandler : ICommandHandler<InviteMembers>
{
    public Task HandleAsync(InviteMembers command)
    {
        throw new NotImplementedException();
    }
}