using AutoMapper;
using Identity.Application.Abstractions.Security;
using Identity.Core.DTO;
using Identity.Core.Repositories;
using Identity.Domain.Identity;
using Microsoft.Extensions.Logging;
using Shared.Application.Abstractions.CQRS;
using Shared.Core.DTO;
using Shared.Core.Objects;

namespace Identity.Application.Queries.SignUp;

public sealed class SignUpHandler(
    IUserIdentityRepository userIdentityRepository,
    IRoleRepository userRoleRepository,
    IPasswordManager passwordManager,
    IMapper mapper,
    ILogger<SignUpHandler> logger
    )
    : IQueryHandler<SignUp, IdentityDto>
{
    public async Task<Result<IdentityDto>> Handle(SignUp request, CancellationToken cancellationToken)
    {
        var securedPassword = passwordManager.Secure(request.Password);
        var defaultUserRole = await userRoleRepository.GetDefaultRoleAsync();
        var user = new UserIdentity(
            request.Email,
            request.Username,
            securedPassword,
            request.Name,
            request.Surname,
            defaultUserRole.Id);
        
        user.Raise(new UserIdentitySignUpDomainEvent(mapper.Map<IdentityDto>(user)));
        var result = await userIdentityRepository.AddUserIdentityAsync(user);

        return mapper.Map<IdentityDto>(result);
    }
}