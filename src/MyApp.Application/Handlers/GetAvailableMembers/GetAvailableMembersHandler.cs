using AutoMapper;
using MyApp.Core.DTO;
using MyApp.Core.Repositories;

namespace MyApp.Application.Handlers.GetAvailableMembers;

public class GetAvailableMembersHandler : IGetAvailableMembersHandler
{
    private readonly IMapper _mapper;
    private readonly IMemberRepository _memberRepository;

    public GetAvailableMembersHandler(IMemberRepository memberRepository, IMapper mapper)
    {
        _memberRepository = memberRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<HateoasUserDto>> HandleAsync()
    {
        var availableMembers = await _memberRepository.GetAvailableMembers();
        var users=_mapper.Map<IEnumerable<HateoasUserDto>>(availableMembers);
        foreach (var user in users)
        {
            user.generateLinks();
        }

        return users;
    }
}