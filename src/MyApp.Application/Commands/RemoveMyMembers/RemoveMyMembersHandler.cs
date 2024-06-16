using MyApp.Application.Abstractions;
using MyApp.Core.Repositories;

namespace MyApp.Application.Commands.RemoveMembers;

public class RemoveMyMembersHandler : ICommandHandler<RemoveMyMembers>
{
    private readonly IMemberRepository _memberRepository;

    public RemoveMyMembersHandler(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task HandleAsync(RemoveMyMembers command)
    {
        await _memberRepository.RemoveMembers(command.Members);
    }
}