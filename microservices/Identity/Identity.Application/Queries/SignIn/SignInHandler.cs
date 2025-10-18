using AutoMapper;
using Identity.Application.Abstractions.Security;
using Identity.Core.DTO;
using Identity.Core.Exceptions;
using Identity.Core.Repositories;
using Shared.Application.Abstractions.CQRS;
using Shared.Core.DTO;
using Shared.Core.Objects;

namespace Identity.Application.Queries.SignIn;

public sealed class SignInHandler(
    IAuthenticator authenticator,
    IHttpContextTokenService httpContextTokenService,
    IPasswordManager passwordManager,
    IMapper mapper,
    IUserIdentityRepository userIdentityRepository)
    : IQueryHandler<SignIn, IdentityDto>

{
    public async Task<Result<IdentityDto>> Handle(SignIn request, CancellationToken cancellationToken)
    {
        var result = await userIdentityRepository.GetUserIdentityByEmailAsync(request.Email);

        if (result is null)
        {
            throw new InvalidCredentialsException();
        }

        if (!passwordManager.Validate(request.Password, result.Password))
        {
            throw new InvalidCredentialsException();
        }

        if (!result.IsActive)
        {
            throw new InvalidCredentialsException();
        }

        var token = authenticator.CreateToken(result.Id, result.Role.Name);
        httpContextTokenService.Set(token);
        return mapper.Map<IdentityDto>(result);
    }
}