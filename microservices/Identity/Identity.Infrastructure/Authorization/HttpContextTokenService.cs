using Identity.Application.Abstractions.Security;
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
}