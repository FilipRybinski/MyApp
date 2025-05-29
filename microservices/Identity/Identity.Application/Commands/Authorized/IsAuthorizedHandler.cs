using AutoMapper;
using Identity.Core.DTO;
using Identity.Core.Repositories;
using Shared.Application.Abstractions.CQRS;
using Shared.Core.DTO;
using Shared.Core.Objects;

namespace Identity.Application.Commands.Authorized;

public sealed class IsAuthorizedHandler(IUserIdentityRepository userIdentityRepository, IMapper mapper)
    : ICommandHandler<IsAuthorized,IdentityDto?>
{
    public async Task<Result<IdentityDto?>> Handle(IsAuthorized request, CancellationToken cancellationToken)
    {
        return Result<IdentityDto?>.Success(mapper.Map<IdentityDto>(await userIdentityRepository.GetSessionUserIdentityAsync()));
    }
}