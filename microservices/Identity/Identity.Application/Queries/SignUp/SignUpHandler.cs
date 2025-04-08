using AutoMapper;
using Identity.Application.Abstractions.Security;
using Identity.Core.DTO;
using Identity.Core.Entities;
using Identity.Core.Repositories;
using Microsoft.Extensions.Logging;
using QueueMailer.Application.Commands.SendConfirmationEmail;
using RequestClient.DTO;
using RequestClient.Handler;
using Shared.Application.Abstractions.CQRS;
using Shared.Application.Routes;
using Shared.Core.Objects;

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
    public async Task<Result<IdentityDto>> Handle(SignUp request, CancellationToken cancellationToken)
    {
        var securedPassword = passwordManager.Secure(request.Password);
        var defaultUserRole = await userRoleRepository.GetDefaultRoleAsync();
        var user = new _Identity(
            request.Email,
            request.Username,
            securedPassword,
            request.Name,
            request.Surname,
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