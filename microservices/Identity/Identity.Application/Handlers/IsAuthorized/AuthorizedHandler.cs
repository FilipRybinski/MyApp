using AutoMapper;
using Identity.Core.DTO;
using Identity.Core.Repositories;

namespace Identity.Application.Handlers.IsAuthorized;

internal sealed class AuthorizedHandler(IUserIdentityRepository userIdentityRepository, IMapper mapper)
    : IAuthorizedHandler
{
    public async Task<IdentityDto?> HandleAsync(CancellationToken cancellationToken)
    {
        return mapper.Map<IdentityDto>(await userIdentityRepository.GetSessionUserIdentityAsync());
    }
}