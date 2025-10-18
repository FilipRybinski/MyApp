using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Shared.Application.Providers.Identity;

namespace Shared.Infrastructure.Providers.Identity;

public class IdentityProvider(IHttpContextAccessor httpContextAccessor) : IIdentityProvider
{
    public Guid? ExtractUserIdentityIdentifier()
    {
        if (Guid.TryParse(httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier),
                out var identifier))
        {
            return identifier;
        }

        return ExtractUserIdentityIdentifierFromCookies();
    }
    
    private Guid? ExtractUserIdentityIdentifierFromCookies()
    {
        var token = httpContextAccessor.HttpContext?.Request.Cookies["token"];
        if (token.IsNullOrEmpty())
        {
            return null;
        }
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