using AutoMapper;
using Identity.Application.Security;
using Identity.Core.DTO;
using Identity.Core.Entities;
using Identity.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using QueueMailer.Application.Commands.SendConfirmationEmail;
using RequestClient.Handler;
using Shared.Core.Abstractions;

namespace Identity.Application.Queries.SignUp;

public sealed class SignUpHandler(
    IUserIdentityRepository userIdentityRepository,
    IRoleRepository userRoleRepository,
    IPasswordManager passwordManager,
    IMapper mapper,
    IRequestHandler requestHandler)
    : IQueryHandler<SignUp, IdentityDto>
{
    public async Task<IdentityDto> HandleAsync(SignUp query)
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

        var result = await userIdentityRepository.AddUserIdentityAsync(user);
        await requestHandler.SendRequestAsync<ConfirmationEmail, IActionResult>(
            "http://localhost:5169/QueueMailer/SendConfirmationEmail",
            HttpMethod.Post,
            new ConfirmationEmail( user.Id, user.Email)
        );
        return mapper.Map<IdentityDto>(result);
        
    }
}