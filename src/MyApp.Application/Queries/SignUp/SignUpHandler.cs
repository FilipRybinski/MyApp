
using AutoMapper;
using Common.Abstractions;
using MyApp.Application.Security;
using MyApp.Core.DTO;
using MyApp.Core.Entities;
using MyApp.Core.Repositories;

namespace MyApp.Application.Queries.SignUp;

public sealed class SignUpHandler : IQueryHandler<SignUp,UserDto>
{
    private readonly IPasswordManager _passwordManager;
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IMapper _mapper;

    public SignUpHandler(IUserRepository userRepository,
        IUserRoleRepository userRoleRepository,
        IPasswordManager passwordManager,
        IMapper mapper
        )
    {
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
        _passwordManager = passwordManager;
        _mapper = mapper;
    }

    public async Task<UserDto> HandleAsync(SignUp query)
    {
        var securedPassword = _passwordManager.Secure(query.Password);
        var defaultUserRole = await _userRoleRepository.GetDefaultRoleAsync();
        var user = new User(
            query.Email,
            query.Username,
            securedPassword,
            query.Name,
            query.Surname,
            defaultUserRole.Id);

        return _mapper.Map<UserDto>(await _userRepository.AddUserAsync(user));
        
    }
}