using AutoMapper;
using Common.Abstractions;
using MyApp.Application.Security;
using MyApp.Core.DTO;
using MyApp.Core.Exceptions;
using MyApp.Core.Repositories;

namespace MyApp.Application.Queries.SignIn;

public class SignInHandler : IQueryHandler<SignIn, UserDto>

{
    private readonly IAuthenticator _authenticator;
    private readonly IHttpContextTokenService _httpContextTokenService;
    private readonly IMapper _mapper;
    private readonly IPasswordManager _passwordManager;
    private readonly IUserRepository _userRepository;

    public SignInHandler(
        IAuthenticator authenticator,
        IHttpContextTokenService httpContextTokenService,
        IPasswordManager passwordManager,
        IMapper mapper,
        IUserRepository userRepository
    )
    {
        _authenticator = authenticator;
        _httpContextTokenService = httpContextTokenService;
        _passwordManager = passwordManager;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<UserDto> HandleAsync(SignIn query)
    {
        var result = await _userRepository.GetUserByEmailAsync(query.Email);

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
        return _mapper.Map<UserDto>(result);
    }
}