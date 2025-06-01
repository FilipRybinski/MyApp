using AutoMapper;
using Identity.Domain.Identity;
using MediatR;
using RequestClient.Handler;
using Shared.Application.Commands.Prepare;
using Shared.Application.Commands.Token;
using Shared.Application.Events;
using Shared.Application.Routes;
using Shared.Core.DTO;
using Shared.Core.Enums;

namespace Identity.Application.Queries.SignUp;

public class SignUpDomainEventHandler(IRequestHandler requestHandler, IRoutes routes, IMapper mapper): INotificationHandler<UserIdentitySignUpDomainEvent>
{
    public async Task Handle(UserIdentitySignUpDomainEvent notification, CancellationToken cancellationToken)
    {
        try
        {
            var tokenResponse = await requestHandler.SendRequestAsync<TokenQuery, TokenDto>(
                routes.RoutesConfiguration.TokenRegistryRoutes.RequestOneTimeToken,
                HttpMethod.Post,
                cancellationToken,
                new TokenQuery(notification.Identity.Id, ResourceType.ActivationToken)
            );

            
            var templateResponse = await requestHandler.SendRequestAsync<PrepareEmail,TemplateDto>(
                routes.RoutesConfiguration.QueueMailerRoutes.PrepareConfirmationEmail,
                HttpMethod.Post,
                cancellationToken,
                new PrepareEmail(notification.Identity,$"{routes.RoutesConfiguration.Host}/identity/confirmation/{notification.Identity.Id}/{tokenResponse.Data.Token}")
            );

            await requestHandler.SendRequestAsync(
                routes.RoutesConfiguration.QueueMailerRoutes.HandleConfirmationEmailEvent,
                HttpMethod.Post,
                cancellationToken,
                new EmailEvent(notification.Identity.Email, templateResponse.Data.TemplateBody)
            );
        }
        catch (Exception e)
        {
            throw e;
        }
        
        
    }
}
