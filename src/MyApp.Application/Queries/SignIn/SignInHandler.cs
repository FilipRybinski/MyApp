using AutoMapper;
using Common.Abstractions;
using MyApp.Application.Security;
using MyApp.Core.DTO;
using MyApp.Core.Repositories;

namespace MyApp.Application.Queries.SignIn;

public class SignInHandler : IQueryHandler<SignIn, UserDto>

{
    private readonly IAuthenticator _authenticator;
    private readonly IHttpContextTokenStorage _httpContextTokenStorage;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

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
        //TODO: IMPLEMENTATION
        throw new NotImplementedException();
    }
}