using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using MyApp.Application.Security;
using MyApp.Core.DTO;

namespace MyApp.Infrastructure.Auth;

internal sealed class HttpContextHttpContextTokenStorage : IHttpContextTokenStorage
{
    private const string TokenKey = "token";
    private readonly IHttpContextAccessor _httpContextAccessor;


    public HttpContextHttpContextTokenStorage(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? GetCurrentUserIdentifier()
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
        _httpContextAccessor.HttpContext.Items.TryAdd(TokenKey, jwt);
        HttpContextResponseInjectToken(jwt);
    }

    private void HttpContextResponseInjectToken(JwtDto jwt)
    {
        var httpOnlyCookie = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(1),
            HttpOnly = true,
            Secure = true,
            IsEssential = true,
            SameSite = SameSiteMode.None
        };
        _httpContextAccessor.HttpContext.Response.Cookies.Append(TokenKey, jwt.AccessToken, httpOnlyCookie);
    }
}