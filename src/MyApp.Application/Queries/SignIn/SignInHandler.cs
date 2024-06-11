using AutoMapper;
using MyApp.Application.Abstractions;
using MyApp.Application.Security;
using MyApp.Core.DTO;
using MyApp.Core.Repositories;

namespace MyApp.Application.Queries.SignIn;

public class SignInHandler : IQueryHandler<SignIn,UserDto>

{
    private readonly IAuthenticator _authenticator;
    private readonly IHttpContextTokenStorage _httpContextTokenStorage;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public SignInHandler(IUserRepository userRepository,
        IAuthenticator authenticator,
        IHttpContextTokenStorage httpContextTokenStorage,
        IMapper mapper
        )
    {
        _userRepository = userRepository;
        _authenticator = authenticator;
        _httpContextTokenStorage = httpContextTokenStorage;
        _mapper = mapper;
    }

    public async Task<UserDto> HandleAsync(SignIn command)
    {
        var user = await _userRepository.IsUserExists(command.Email);
        if (user is null)
        {
            throw new Exception();
        }

        var jwt = _authenticator.CreateToken(user.Id, user.Role.Name);
        _httpContextTokenStorage.Set(jwt);
        return _mapper.Map<UserDto>(user);
    }
}