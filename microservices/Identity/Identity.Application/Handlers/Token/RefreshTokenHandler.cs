using Identity.Application.Security;
using Identity.Core.Repositories;
using RequestClient.Handler;
using Shared.Application.Routes;
using TokenRegistry.Application.Queries.ValidateToken;
using TokenRegistry.Core.DTO;
using TokenRegistry.Core.Enums;

namespace Identity.Application.Handlers.Token;

internal sealed class RefreshTokenHandler(
    IAuthenticator authenticator,
    IHttpContextTokenService httpContextTokenService,
    IUserIdentityRepository userIdentityRepository,
    IRequestHandler requestHandler,
    IRoutes routes
    ) : IRefreshTokenHandler
{
    public async Task HandleAsync(CancellationToken cancellationToken)
    {
        var user = await userIdentityRepository.GetSessionUserIdentityAsync();
        
        if (user == null)
        {
            throw new Exception("test");
        }

        var refreshToken = httpContextTokenService.RetrieveRefreshToken();

        if (refreshToken is null)
        {
            throw new Exception("test2");
        }

        var response = await requestHandler.SendRequestAsync<ValidateToken, ValidateTokenDto>(
            routes.RoutesConfiguration.TokenRegistryRoutes.ValidateToken,
            HttpMethod.Post,
            cancellationToken,
            new ValidateToken()
            {
                IdentityId = user.Id,
                Token = refreshToken,
                ResourceType = ResourceType.RefreshToken,
                TokenType = TokenType.LimitedTimeToken,
            }
        );

        response.HttpResponse.EnsureSuccessStatusCode();

        if (!response.DeserializedResponseBody.IsValid)
        {
            throw new Exception("test3");   
        }
        
        var token = authenticator.CreateToken(user.Id, user.Role.Name);
        await httpContextTokenService.Set(token, user.Id);
    }
}