using AutoMapper;
using Identity.Core.Repositories;
using Identity.Domain.Identity;
using RequestClient.Handler;
using Shared.Application.Abstractions.CQRS;
using Shared.Application.Commands.Token;
using Shared.Application.Events;
using Shared.Application.Routes;
using Shared.Core.DTO;
using Shared.Core.Enums;
using Shared.Core.Objects;

namespace Identity.Application.Commands.Activation;

public sealed class ActivationActionHandler(
    IUserIdentityRepository userIdentityRepository,
    IRequestHandler requestHandler,
    IRoutes routes,
    IMapper mapper
    ) : ICommandHandler<ActivationAction>
{
    public async Task<Result> Handle(ActivationAction request, CancellationToken cancellationToken)
    {
        var user = await userIdentityRepository.GetUserIdentityByIdAsync(request.Id);

        if (user is null)
        {
            return Result.Failure(Error.BadRequest("Invalid token"));
        }
        
        var validationResponse = await requestHandler.SendRequestAsync<ValidateToken,TokenValidationDto>(
            routes.RoutesConfiguration.TokenRegistryRoutes.ValidateToken,
            HttpMethod.Post,
            cancellationToken,
            new ValidateToken(user.Id, ResourceType.ActivationToken, request.Token,TokenType.OneTimeToken)
        );

        if (validationResponse.Data is { IsValid: false })
        {
            return Result.Failure(Error.BadRequest("Invalid token"));
        }

        user.Raise(new UserIdentityActivationDomainEvent(mapper.Map<IdentityDto>(user)));
        await userIdentityRepository.UserIdentityActivationAsync(user);
        
        return Result.Success();
    }
}