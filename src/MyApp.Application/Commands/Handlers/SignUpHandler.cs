using MyApp.Application.Abstractions;
using MyApp.Application.Security;
using MyApp.Core.Entities;
using MyApp.Core.Repositories;

namespace MyApp.Application.Commands.Handlers;

public sealed class SignUpHandler : ICommandHandler<SignUp>
{
    private readonly IPasswordManager _passwordManager;
    private readonly IUserRepository _userRepository;
    private readonly IAuthenticator _authenticator;
    private readonly ITokenStorage _tokenStorage;
    public SignUpHandler(IUserRepository userRepository,IPasswordManager passwordManager, IAuthenticator authenticator,ITokenStorage tokenStorage)
    {
        _userRepository = userRepository;
        _passwordManager = passwordManager;
        _authenticator = authenticator;
        _tokenStorage = tokenStorage;
    }
    public async Task HandleAsync(SignUp command)
    {

        var securedPassword = _passwordManager.Secure(command.Password);
        var user = new User(command.UserId,
            command.Email,
            securedPassword,
            command.Name,
            command.Surname,
            command.Role,
            new DateTime());
        
        await _userRepository.AddUserAsync(user);
        var jwt = _authenticator.CreateToken(user.Id, user.Role);
        _tokenStorage.Set(jwt);

    }
}