using AutoMapper;
using Identity.Application.Security;
using Identity.Core.DTO;
using Identity.Core.Entities;
using Identity.Core.Repositories;
using Microsoft.Extensions.Logging;
using QueueMailer.Application.Commands.SendConfirmationEmail;
using RequestClient.DTO;
using RequestClient.Handler;
using Shared.Application.Routes;
using Shared.Core.Abstractions;

namespace Identity.Application.Queries.SignUp;

public sealed class SignUpHandler(
    IUserIdentityRepository userIdentityRepository,
    IRoleRepository userRoleRepository,
    IPasswordManager passwordManager,
    IMapper mapper,
    IRequestHandler requestHandler,
    IRoutes routes,
    ILogger<SignUpHandler> logger
    )
    : IQueryHandler<SignUp, IdentityDto>
{
    public async Task<IdentityDto> HandleAsync(SignUp query, CancellationToken cancellationToken)
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
        
        var response =  await requestHandler.SendRequestAsync<ConfirmationEmail, RequestClientResponseNoContent>(
            routes.RoutesConfiguration.QueueMailerRoutes.SendConfirmationEmail,
            HttpMethod.Post,
            cancellationToken,
            new ConfirmationEmail(user.Id, user.Email)
        );

        response.HttpResponse.EnsureSuccessStatusCode();
        
        var result = await userIdentityRepository.AddUserIdentityAsync(user);
        return mapper.Map<IdentityDto>(result);
     
    }
}