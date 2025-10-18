using Identity.Domain.Identity;
using MediatR;
using RequestClient.Handler;
using Shared.Application.Commands.Prepare;
using Shared.Application.Events;
using Shared.Application.Routes;
using Shared.Core.DTO;

namespace Identity.Application.Commands.Activation;

public class ActivationDomainEventHandler(IRequestHandler requestHandler,IRoutes routes): INotificationHandler<UserIdentityActivationDomainEvent>
{
    public async Task Handle(UserIdentityActivationDomainEvent notification, CancellationToken cancellationToken)
    {

            var templateResponse = await requestHandler.SendRequestAsync<PrepareEmail,TemplateDto>(
                routes.RoutesConfiguration.QueueMailerRoutes.PrepareActivationEmail,
                HttpMethod.Post,
                cancellationToken,
                new PrepareEmail(notification.Identity,routes.RoutesConfiguration.Host)
            );

            await requestHandler.SendRequestAsync(
                routes.RoutesConfiguration.QueueMailerRoutes.HandleActivationEmailEvent,
                HttpMethod.Post,
                cancellationToken,
                new EmailEvent(notification.Identity.Email, templateResponse.Data.TemplateBody)
            );
    }
}