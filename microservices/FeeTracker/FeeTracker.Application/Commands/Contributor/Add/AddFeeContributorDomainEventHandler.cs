using FeeTracker.Domain.Contributor;
using MediatR;
using Shared.Application.Routes;
using RequestClient.Handler;
using Shared.Application.Commands.Prepare;
using Shared.Application.Events;
using Shared.Core.DTO;

namespace FeeTracker.Application.Commands.Contributor.Add;

public class AddFeeContributorDomainEventHandler(IRequestHandler requestHandler,IRoutes routes): INotificationHandler<FeeContributorCreatedDomainEvent>
{
    public async Task Handle(FeeContributorCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var templateResponse = await requestHandler.SendRequestAsync<PrepareEmail,TemplateDto>(
            routes.RoutesConfiguration.QueueMailerRoutes.PrepareCreateContributorEmail,
            HttpMethod.Post,
            cancellationToken,
            new PrepareEmail(notification.Identity,null)
        );

        await requestHandler.SendRequestAsync(
            routes.RoutesConfiguration.QueueMailerRoutes.HandleCreateContributorEvent,
            HttpMethod.Post,
            cancellationToken,
            new EmailEvent(notification.Identity.Email, templateResponse.Data.TemplateBody)
        );
    }
}