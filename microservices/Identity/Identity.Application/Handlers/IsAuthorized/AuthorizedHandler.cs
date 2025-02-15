using AutoMapper;
using Identity.Core.DTO;
using Identity.Core.Repositories;

namespace Identity.Application.Handlers.IsAuthorized;

public class AuthorizedHandler(IUserIdentityRepository userIdentityRepository, IMapper mapper)
    : IAuthorizedHandler
{
    public async Task<IdentityDto?> HandleAsync()
    {
        return mapper.Map<IdentityDto>(await userIdentityRepository.GetSessionUserIdentityAsync());
    }
}