using AutoMapper;
using Identity.Core.DTO;
using Identity.Core.Repositories;

namespace Identity.Application.Handlers.IsAuthorized;

public class AuthorizedHandler : IAuthorizedHandler
{
    private readonly IUserIdentityRepository _userIdentityRepository;
    private readonly IMapper _mapper;

    public AuthorizedHandler(IUserIdentityRepository userIdentityRepository,IMapper mapper)
    {
        _userIdentityRepository = userIdentityRepository;
        _mapper = mapper;
    }
    
    public async Task<IdentityDto?> HandleAsync()
    {
        return _mapper.Map<IdentityDto>(await _userIdentityRepository.GetSessionUserIdentityAsync());
    }
}