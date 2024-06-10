using MyApp.Application.Abstractions;
using MyApp.Core.Repositories;

namespace MyApp.Application.Commands.RemoveMembers;

public class RemoveMembersHandler : ICommandHandler<RemoveMembers>
{
    private readonly IMemberRepository _memberRepository;

    public RemoveMembersHandler(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task HandleAsync(RemoveMembers command)
    {
    }
}