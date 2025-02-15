using AutoMapper;
using Identity.Application.Security;
using Identity.Core.DTO;
using Identity.Core.Entities;
using Identity.Core.Repositories;
using Shared.Abstractions;

namespace Identity.Application.Queries.SignUp;

public sealed class SignUpHandler(
    IUserIdentityRepository userIdentityRepository,
    IRoleRepository userRoleRepository,
    IPasswordManager passwordManager,
    IMapper mapper)
    : IQueryHandler<SignUp, IdentityDto>
{
    public async Task<IdentityDto> HandleAsync(Identity.Application.Queries.SignUp.SignUp query)
    {
        var securedPassword = passwordManager.Secure(query.Password);
        var defaultUserRole = await userRoleRepository.GetDefaultRoleAsync();
        var user = new _Identity(
            query.Email,
            query.Username,
            securedPassword,
            query.Name,
            query.Surname,
            defaultUserRole.Id);

        return mapper.Map<IdentityDto>(await userIdentityRepository.AddUserIdentityAsync(user));
        
    }
}