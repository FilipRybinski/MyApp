using System.Security.Claims;
using Identity.Application.Security;
using Identity.Core.DTO;
using Identity.Infrastructure.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Identity.Infrastructure.Authorization;

internal sealed class HttpContextTokenService : IHttpContextTokenService
{
    private const string TokenKey = "token";
    private readonly CookieSettingsOptions CookieSettings;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpContextTokenService(IHttpContextAccessor httpContextAccessor,IOptions<CookieSettingsOptions> cookieSettings)
    {
        _httpContextAccessor = httpContextAccessor;
        CookieSettings = cookieSettings.Value;
    }

    public Guid? ExtractUserIdentityIdentifier()
    {
        if (Guid.TryParse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier),
                out var identifier))
        {
            return identifier;
        }

        return null;
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
        _httpContextAccessor.HttpContext.Response.Cookies.Append(TokenKey, string.Empty, httpOnlyCookie);
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
        _httpContextAccessor.HttpContext.Response.Cookies.Append(TokenKey, jwt.AccessToken, httpOnlyCookie);
    }
}