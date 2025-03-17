using System.Security.Claims;
using Identity.Application.Security;
using Identity.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using RequestClient.Handler;
using Shared.Application.Routes;
using Shared.Core.Configuration;
using TokenRegistry.Application.Queries.LimitedTimeToken;
using TokenRegistry.Core.DTO;
using TokenRegistry.Core.Enums;

namespace Identity.Infrastructure.Authorization;

internal sealed class HttpContextTokenService(
    IHttpContextAccessor httpContextAccessor,
    IRequestHandler requestHandler,
    IRoutes routes,
    IOptions<CookieSettingsConfiguration> cookieSettings)
    : IHttpContextTokenService
{
    private readonly CookieSettingsConfiguration CookieSettings = cookieSettings.Value;

    public Guid? ExtractUserIdentityIdentifier()
    {
        if (Guid.TryParse(httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier),
                out var identifier))
        {
            return identifier;
        }

        return null;
    }

    public string RetrieveRefreshToken() => httpContextAccessor.HttpContext.Request.Cookies["refreshToken"];

    public async Task Set(JwtDto jwt,Guid identityId)
    {
        var refreshToken = await RetrieveRefreshToken(identityId);
        HttpContextResponseInjectToken(jwt, refreshToken);
    }

    public void Remove()
    {
        HttpContextResponseExtractToken();
    }

    private void HttpContextResponseExtractToken()
    {
        var httpOnlyCookie = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(-CookieSettings.ExpireTime),
            HttpOnly = true,
            Secure = true,
            IsEssential = true,
            SameSite = SameSiteMode.None,
            Path = CookieSettings.Path,
            Domain = CookieSettings.Domain,
            
            
        };
        httpContextAccessor.HttpContext.Response.Cookies.Append("token", string.Empty, httpOnlyCookie);
    }
    
    private void HttpContextResponseInjectToken(JwtDto jwt,string refreshToken)
    {
        var accessTokenHttpOnlyCookie = new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            IsEssential = true,
            SameSite = SameSiteMode.None,
            Path = CookieSettings.Path,
            Domain = CookieSettings.Domain,
        };
        
        var refreshTokenHttpOnlyCookie = new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            IsEssential = true,
            SameSite = SameSiteMode.None,
            Path = CookieSettings.Path,
            Domain = CookieSettings.Domain,
        };
        
        httpContextAccessor.HttpContext.Response.Cookies.Append("token", jwt.AccessToken, accessTokenHttpOnlyCookie);
        httpContextAccessor.HttpContext.Response.Cookies.Append("refreshToken", refreshToken, refreshTokenHttpOnlyCookie);
    }
    
    private async Task<string> RetrieveRefreshToken(Guid identityId)
    {       
        var refreshToken = await requestHandler.SendRequestAsync<LimitedTimeQueryToken, TokenDto>(
            routes.RoutesConfiguration.TokenRegistryRoutes.RequestLimitedTimeToken,
            HttpMethod.Post,
            default,
            new LimitedTimeQueryToken()
            {
                IdentityId = identityId,
                ResourceType = ResourceType.RefreshToken,
            });

        refreshToken.HttpResponse.EnsureSuccessStatusCode();
        
        return refreshToken.DeserializedResponseBody.Token;
    }
}