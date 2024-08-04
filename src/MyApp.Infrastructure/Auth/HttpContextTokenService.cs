using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using MyApp.Application.Security;
using MyApp.Core.DTO;

namespace MyApp.Infrastructure.Auth;

internal sealed class HttpContextTokenService : IHttpContextTokenService
{
    private const string TokenKey = "token";
    private const int ExpireTime = 1;
    private readonly IHttpContextAccessor _httpContextAccessor;


    public HttpContextTokenService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? ExtractUserIdentifier()
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
            Expires = DateTime.Now.AddDays(-ExpireTime),
            HttpOnly = true,
            Secure = true,
            IsEssential = true,
            SameSite = SameSiteMode.None
        };
        _httpContextAccessor.HttpContext.Response.Cookies.Append(TokenKey, string.Empty, httpOnlyCookie);
    }

    private void HttpContextResponseInjectToken(JwtDto jwt)
    {
        var httpOnlyCookie = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(ExpireTime),
            HttpOnly = true,
            Secure = true,
            IsEssential = true,
            SameSite = SameSiteMode.None
        };
        _httpContextAccessor.HttpContext.Response.Cookies.Append(TokenKey, jwt.AccessToken, httpOnlyCookie);
    }
}