using AutoMapper;
using Identity.Application.Security;
using Identity.Core.DTO;
using Identity.Core.Exceptions;
using Identity.Core.Repositories;
using Shared.Abstractions;
using IAuthenticator = Identity.Application.Security.IAuthenticator;
using IHttpContextTokenService = Identity.Application.Security.IHttpContextTokenService;

namespace Identity.Application.Queries.SignIn;

public class SignInHandler : IQueryHandler<SignIn, IdentityDto>

{
    private readonly IAuthenticator _authenticator;
    private readonly IHttpContextTokenService _httpContextTokenService;
    private readonly IMapper _mapper;
    private readonly IPasswordManager _passwordManager;
    private readonly IUserIdentityRepository _userIdentityRepository;

    public SignInHandler(
        IAuthenticator authenticator,
        IHttpContextTokenService httpContextTokenService,
        IPasswordManager passwordManager,
        IMapper mapper,
        IUserIdentityRepository userIdentityRepository
    )
    {
        _authenticator = authenticator;
        _httpContextTokenService = httpContextTokenService;
        _passwordManager = passwordManager;
        _mapper = mapper;
        _userIdentityRepository = userIdentityRepository;
    }

    public async Task<IdentityDto> HandleAsync(SignIn query)
    {
        var result = await _userIdentityRepository.GetUserIdentityByEmailAsync(query.Email);

        if (result is null)
        {
            throw new InvalidCredentialsException();
        }

        if (!_passwordManager.Validate(query.Password, result.Password))
        {
            throw new InvalidCredentialsException();
        }

        var token = _authenticator.CreateToken(result.Id, result.Role.Name);
        _httpContextTokenService.Set(token);
        return _mapper.Map<IdentityDto>(result);
    }
}