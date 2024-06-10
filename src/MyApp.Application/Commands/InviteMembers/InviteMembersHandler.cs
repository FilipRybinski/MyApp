using MyApp.Application.Abstractions;
using MyApp.Core.Repositories;

namespace MyApp.Application.Commands.InviteMembers;

public class InviteMembersHandler : ICommandHandler<InviteMembers>
{
    private readonly IMemberRepository _memberRepository;

    public InviteMembersHandler(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task HandleAsync(InviteMembers command)
    {
        await _memberRepository.InviteMembers(command.Members);
    }
}