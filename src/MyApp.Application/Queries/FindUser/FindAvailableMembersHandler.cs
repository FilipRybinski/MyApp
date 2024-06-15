using AutoMapper;
using MyApp.Application.Abstractions;
using MyApp.Core.DTO;
using MyApp.Core.Repositories;

namespace MyApp.Application.Queries.FindUser;

public class FindAvailableMembersHandler : IQueryHandler<FindAvailableMembers, IEnumerable<UserDto>>
{
    private readonly IMapper _mapper;
    private readonly IMemberRepository _memberRepository;

    public FindAvailableMembersHandler(IMemberRepository memberRepository, IMapper mapper)
    {
        _memberRepository = memberRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> HandleAsync(FindAvailableMembers query)
    {
        var users = await _memberRepository.FindAvailableMember(query.Name);
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }
}