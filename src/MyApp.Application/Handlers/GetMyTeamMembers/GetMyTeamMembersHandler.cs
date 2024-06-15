using AutoMapper;
using MyApp.Core.DTO;
using MyApp.Core.Repositories;

namespace MyApp.Application.Handlers.GetMyTeamMembers;

public class GetMyTeamMembersHandler : IGetMyTeamMembersHandler
{
    private readonly IMapper _mapper;
    private readonly IMemberRepository _memberRepository;

    public GetMyTeamMembersHandler(IMemberRepository memberRepository, IMapper mapper)
    {
        _memberRepository = memberRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> HandleAsync()
    {
        var members = await _memberRepository.GetMyTeamMembers();
        return _mapper.Map<IEnumerable<UserDto>>(members);
    }
}