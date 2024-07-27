
using Common.Abstractions;
using MyApp.Application.Security;
using MyApp.Core.Entities;
using MyApp.Core.Repositories;

namespace MyApp.Application.Commands.SignUp;

public sealed class SignUpHandler : ICommandHandler<SignUp>
{
    private readonly IPasswordManager _passwordManager;
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;

    public SignUpHandler(IUserRepository userRepository,
        IUserRoleRepository userRoleRepository,
        IPasswordManager passwordManager)
    {
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
        _passwordManager = passwordManager;
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
    }
}