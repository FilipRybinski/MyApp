using AutoMapper;
using Identity.Application.Security;
using Identity.Core.DTO;
using Identity.Core.Exceptions;
using Identity.Core.Repositories;
using Shared.Core.Abstractions;

namespace Identity.Application.Queries.SignIn;

public sealed class SignInHandler(
    IAuthenticator authenticator,
    IHttpContextTokenService httpContextTokenService,
    IPasswordManager passwordManager,
    IMapper mapper,
    IUserIdentityRepository userIdentityRepository)
    : IQueryHandler<SignIn, IdentityDto>

{
    public async Task<IdentityDto> HandleAsync(SignIn query, CancellationToken cancellationToken)
    {
        var result = await userIdentityRepository.GetUserIdentityByEmailAsync(query.Email);

        if (result is null)
        {
            throw new InvalidCredentialsException();
        }

        if (!passwordManager.Validate(query.Password, result.Password))
        {
            throw new InvalidCredentialsException();
        }

        var token = authenticator.CreateToken(result.Id, result.Role.Name);
        await httpContextTokenService.Set(token,result.Id);
        return mapper.Map<IdentityDto>(result);
    }
}