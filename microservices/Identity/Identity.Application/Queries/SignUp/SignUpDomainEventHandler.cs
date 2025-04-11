using AutoMapper;
using Identity.Domain.Identity;
using MediatR;
using RequestClient.Handler;
using Shared.Application.Commands.SendConfirmationEmail;
using Shared.Application.Routes;

namespace Identity.Application.Queries.SignUp;

public class SignUpDomainEventHandler(IRequestHandler requestHandler, IRoutes routes, IMapper mapper): INotificationHandler<UserIdentitySignUpDomainEvent>
{
    public async Task Handle(UserIdentitySignUpDomainEvent notification, CancellationToken cancellationToken)
    {
        var body = mapper.Map<ConfirmationEmail>(notification);
        var response =  await requestHandler.SendRequestAsync(
            routes.RoutesConfiguration.QueueMailerRoutes.SendConfirmationEmail,
            HttpMethod.Post,
            cancellationToken,
            body
        );
    }
}
