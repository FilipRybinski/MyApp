using MyApp.Application.Abstractions;
using MyApp.Application.Security;
using MyApp.Core.Entities;
using MyApp.Core.Repositories;

namespace MyApp.Application.Commands.SignUp;

public sealed class SignUpHandler : ICommandHandler<SignUp>
{
    private readonly IAuthenticator _authenticator;
    private readonly IHttpContextTokenStorage _httpContextTokenStorage;
    private readonly IPasswordManager _passwordManager;
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;

    public SignUpHandler(IUserRepository userRepository, IUserRoleRepository userRoleRepository,
        IPasswordManager passwordManager, IAuthenticator authenticator,
        IHttpContextTokenStorage httpContextTokenStorage)
    {
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
        _passwordManager = passwordManager;
        _authenticator = authenticator;
        _httpContextTokenStorage = httpContextTokenStorage;
    }

    public async Task HandleAsync(SignUp command)
    {
        var securedPassword = _passwordManager.Secure(command.Password);
        var defaultUserRole = await _userRoleRepository.GetDefaultRoleAsync();
        var user = new User(
            command.Email,
            command.Username,
            securedPassword,
            command.Name,
            command.Surname,
            defaultUserRole.Id);

        await _userRepository.AddUserAsync(user);
        var jwt = _authenticator.CreateToken(user.Id, defaultUserRole.Name);
        _httpContextTokenStorage.Set(jwt);
    }
}