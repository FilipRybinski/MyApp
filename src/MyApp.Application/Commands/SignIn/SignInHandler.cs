using MyApp.Application.Abstractions;
using MyApp.Application.Security;
using MyApp.Core.Repositories;

namespace MyApp.Application.Commands.SignIn;

public class SignInHandler : ICommandHandler<SignIn>
{
    private readonly IAuthenticator _authenticator;
    private readonly ITokenStorage _tokenStorage;
    private readonly IUserRepository _userRepository;
    
    public SignInHandler(IUserRepository userRepository, IAuthenticator authenticator,ITokenStorage tokenStorage)
    {
        _userRepository = userRepository;
        _authenticator = authenticator;
        _tokenStorage = tokenStorage;
    }
    public async Task HandleAsync(SignIn command)
    {
        var user = await _userRepository.IsUserExists(command.Email);
        if (user is null)
        {
            throw new Exception();
        }
        
        var jwt = _authenticator.CreateToken(user.Id, user.Role.Name);
        _tokenStorage.Set(jwt);
    }
}