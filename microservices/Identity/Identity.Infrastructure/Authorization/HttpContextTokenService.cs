using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Identity.Application.Security;
using Identity.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Shared.Core.Configuration;

namespace Identity.Infrastructure.Authorization;

internal sealed class HttpContextTokenService(
    IHttpContextAccessor httpContextAccessor,
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

        return ExtractUserIdentityIdentifierFromCookies();
    }

    public void Set(JwtDto jwt)
    {
        HttpContextResponseInjectToken(jwt);
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

    private void HttpContextResponseInjectToken(JwtDto jwt)
    {
        var httpOnlyCookie = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(CookieSettings.ExpireTime),
            HttpOnly = true,
            Secure = true,
            IsEssential = true,
            SameSite = SameSiteMode.None,
            Path = CookieSettings.Path,
            Domain = CookieSettings.Domain,
        };
        httpContextAccessor.HttpContext.Response.Cookies.Append("token", jwt.AccessToken, httpOnlyCookie);
    }

    private Guid? ExtractUserIdentityIdentifierFromCookies()
    {
        var token = httpContextAccessor.HttpContext?.Request.Cookies["token"];
        
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);
        
        if (Guid.TryParse(jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value,
                out var identifier))
        {
            return identifier;
        }

        return null;
    }
}