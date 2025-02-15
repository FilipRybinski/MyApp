using AutoMapper;
using Identity.Application.Security;
using Identity.Core.DTO;
using Identity.Core.Exceptions;
using Identity.Core.Repositories;
using Shared.Abstractions;
using IAuthenticator = Identity.Application.Security.IAuthenticator;
using IHttpContextTokenService = Identity.Application.Security.IHttpContextTokenService;

namespace Identity.Application.Queries.SignIn;

public class SignInHandler(
    IAuthenticator authenticator,
    IHttpContextTokenService httpContextTokenService,
    IPasswordManager passwordManager,
    IMapper mapper,
    IUserIdentityRepository userIdentityRepository)
    : IQueryHandler<SignIn, IdentityDto>

{
    public async Task<IdentityDto> HandleAsync(SignIn query)
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
        httpContextTokenService.Set(token);
        return mapper.Map<IdentityDto>(result);
    }
}