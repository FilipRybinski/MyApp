using AutoMapper;
using Identity.Domain.Identity;
using MediatR;
using RequestClient.DTO;
using RequestClient.Handler;
using Shared.Application.Commands.SendConfirmationEmail;
using Shared.Application.Routes;

namespace Identity.Application.Queries.SignUp;

public class SignUpDomainEventHandler(IRequestHandler requestHandler, IRoutes routes, IMapper mapper): INotificationHandler<UserIdentitySignUpDomainEvent>
{
    public async Task Handle(UserIdentitySignUpDomainEvent notification, CancellationToken cancellationToken)
    {
        var response =  await requestHandler.SendRequestAsync<ConfirmationEmail, RequestClientResponseNoContent>(
            routes.RoutesConfiguration.QueueMailerRoutes.SendConfirmationEmail,
            HttpMethod.Post,
            cancellationToken,
            mapper.Map<ConfirmationEmail>(notification)
        );

        response.HttpResponse.EnsureSuccessStatusCode();
    }
}
