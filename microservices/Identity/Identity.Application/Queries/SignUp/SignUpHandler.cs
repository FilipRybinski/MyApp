using AutoMapper;
using Identity.Application.Security;
using Identity.Core.DTO;
using Identity.Core.Entities;
using Identity.Core.Repositories;
using Shared.Abstractions;

namespace Identity.Application.Queries.SignUp;

public sealed class SignUpHandler : IQueryHandler<SignUp,IdentityDto>
{
    private readonly IPasswordManager _passwordManager;
    private readonly IUserIdentityRepository _userIdentityRepository;
    private readonly IRoleRepository _userRoleRepository;
    private readonly IMapper _mapper;

    public SignUpHandler(IUserIdentityRepository userIdentityRepository,
        IRoleRepository userRoleRepository,
        IPasswordManager passwordManager,
        IMapper mapper
        )
    {
        _userIdentityRepository = userIdentityRepository;
        _userRoleRepository = userRoleRepository;
        _passwordManager = passwordManager;
        _mapper = mapper;
    }

    public async Task<IdentityDto> HandleAsync(Identity.Application.Queries.SignUp.SignUp query)
    {
        var securedPassword = _passwordManager.Secure(query.Password);
        var defaultUserRole = await _userRoleRepository.GetDefaultRoleAsync();
        var user = new _Identity(
            query.Email,
            query.Username,
            securedPassword,
            query.Name,
            query.Surname,
            defaultUserRole.Id);

        return _mapper.Map<IdentityDto>(await _userIdentityRepository.AddUserIdentityAsync(user));
        
    }
}