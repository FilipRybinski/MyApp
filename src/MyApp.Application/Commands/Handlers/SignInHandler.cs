using MyApp.Application.Abstractions;
using MyApp.Application.Security;

namespace MyApp.Application.Commands.Handlers;

public class SignInHandler : ICommandHandler<SignIn>
{
    private readonly IAuthenticator _authenticator;
    private readonly ITokenStorage _tokenStorage;
    
    public SignInHandler(IAuthenticator authenticator,ITokenStorage tokenStorage)
    {
        _authenticator = authenticator;
        _tokenStorage = tokenStorage;
    }
    public async Task HandleAsync(SignIn command)
    {
        
        var jwt = _authenticator.CreateToken(Guid.NewGuid(), command.password);
        _tokenStorage.Set(jwt);
        
    }
}