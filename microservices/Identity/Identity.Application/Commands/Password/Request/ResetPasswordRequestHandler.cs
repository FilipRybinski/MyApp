using AutoMapper;
using Identity.Core.Repositories;
using RequestClient.Handler;
using Shared.Application.Abstractions.CQRS;
using Shared.Application.Commands.Prepare;
using Shared.Application.Commands.Token;
using Shared.Application.Events;
using Shared.Application.Routes;
using Shared.Core.DTO;
using Shared.Core.Enums;
using Shared.Core.Objects;

namespace Identity.Application.Commands.Password.Request;

public class ResetPasswordRequestHandler(
    IUserIdentityRepository userIdentityRepository,
    IRequestHandler requestHandler,
    IMapper mapper,
    IRoutes routes
    ) : ICommandHandler<ResetPasswordRequest>
{
    public async Task<Result> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
    {
        var user = await userIdentityRepository.GetUserIdentityByEmailAsync(request.Email);

        var tokenResponse = await requestHandler.SendRequestAsync<TokenQuery, TokenDto>(
            routes.RoutesConfiguration.TokenRegistryRoutes.RequestOneTimeToken,
            HttpMethod.Post,
            cancellationToken,
            new TokenQuery(user.Id, ResourceType.ResetPasswordToken)
        );
        
        var templateResponse = await requestHandler.SendRequestAsync<PrepareEmail,TemplateDto>(
            routes.RoutesConfiguration.QueueMailerRoutes.PrepareResetPasswordEmail,
            HttpMethod.Post,
            cancellationToken,
            new PrepareEmail(mapper.Map<IdentityDto>(user),$"{routes.RoutesConfiguration.Host}/identity/reset-password/{user.Id}/{tokenResponse.Data.Token}")
        );
        
        await requestHandler.SendRequestAsync(
            routes.RoutesConfiguration.QueueMailerRoutes.HandleResetPasswordEmailEvent,
            HttpMethod.Post,
            cancellationToken,
            new EmailEvent(request.Email, templateResponse.Data.TemplateBody)
        );

        return Result.Success();
    }
}