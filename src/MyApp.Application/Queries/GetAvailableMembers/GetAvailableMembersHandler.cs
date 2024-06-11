using AutoMapper;
using MyApp.Application.Abstractions;
using MyApp.Core.DTO;
using MyApp.Core.Repositories;

namespace MyApp.Application.Queries.GetAvailableMembers;

public class GetAvailableMembersHandler : IEmptyQueryHandler<IEnumerable<UserDto>>
{
    private readonly IMapper _mapper;
    private readonly IMemberRepository _memberRepository;

    public GetAvailableMembersHandler(IMemberRepository memberRepository, IMapper mapper)
    {
        _memberRepository = memberRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> HandleAsync()
    {
        var availableMembers = await _memberRepository.GetAvailableMembers();
        return _mapper.Map<IEnumerable<UserDto>>(availableMembers);
    }
}