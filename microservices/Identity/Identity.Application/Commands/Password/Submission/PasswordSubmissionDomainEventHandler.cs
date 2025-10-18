using Identity.Domain.Identity;
using MediatR;
using RequestClient.Handler;
using Shared.Application.Commands.Prepare;
using Shared.Application.Events;
using Shared.Application.Routes;
using Shared.Core.DTO;

namespace Identity.Application.Commands.Password.Submission;

public class PasswordSubmissionDomainEventHandler(
    IRequestHandler requestHandler,
    IRoutes routes
    ) : INotificationHandler<UserIdentityPasswordSubmissionDomainEvent>
{
    public async Task Handle(UserIdentityPasswordSubmissionDomainEvent notification, CancellationToken cancellationToken)
    {
        var templateResponse = await requestHandler.SendRequestAsync<PrepareEmail,TemplateDto>(
            routes.RoutesConfiguration.QueueMailerRoutes.PreparePasswordSubmissionEmail,
            HttpMethod.Post,
            cancellationToken,
            new PrepareEmail(notification.Identity,default)
        );
        
        await requestHandler.SendRequestAsync(
            routes.RoutesConfiguration.QueueMailerRoutes.HandlePasswordSubmissionEvent,
            HttpMethod.Post,
            cancellationToken,
            new EmailEvent(notification.Identity.Email, templateResponse.Data.TemplateBody)
        );
    }
}