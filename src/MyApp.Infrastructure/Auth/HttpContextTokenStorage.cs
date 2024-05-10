using Microsoft.AspNetCore.Http;
using MyApp.Application.DTO;
using MyApp.Application.Security;

namespace MyApp.Infrastructure.Auth;

internal sealed class HttpContextTokenStorage : ITokenStorage
{
    private const string TokenKey = "token";
    private readonly IHttpContextAccessor _httpContextAccessor;
    

    public HttpContextTokenStorage(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void Set(JwtDto jwt)
    {
        _httpContextAccessor.HttpContext.Items.TryAdd(TokenKey, jwt);
        HttpContextResponseInjectToken(jwt);
    } 

    public JwtDto Get()
    {
        if (_httpContextAccessor.HttpContext is null)
        {
            return null;
        }

        if (_httpContextAccessor.HttpContext.Items.TryGetValue(TokenKey, out var jwt))
        {
            return jwt as JwtDto;
        }

        if (_httpContextAccessor.HttpContext.Request.Cookies.TryGetValue(TokenKey, out var coookieJwt))
        {
            return new JwtDto{ AccessToken = coookieJwt} ;
        }

        return null;
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
        _httpContextAccessor.HttpContext.Response.Cookies.Append(TokenKey,jwt.AccessToken,httpOnlyCookie);
    }
}