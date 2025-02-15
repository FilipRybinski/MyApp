using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Identity.Application.Security;
using Identity.Core.DTO;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shared.Authorization;
using Shared.Options;

namespace Identity.Infrastructure.Authorization;

internal sealed class Authenticator(IOptions<AuthorizationOptions> options) : IAuthenticator
{
    private readonly string _audience = options.Value.Audience;
    private readonly TimeSpan _expiry = options.Value.Expiry ?? TimeSpan.FromHours(1);
    private readonly string _issuer = options.Value.Issuer;
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
    private readonly SigningCredentials _signingCredentials = new(
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SigningKey)),
        SecurityAlgorithms.HmacSha256);

    public JwtDto CreateToken(Guid id, string roleName)
    {
        var now = DateTime.Now;
        var expires = now.Add(_expiry);
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier,id.ToString()),
            new(JwtRegisteredClaimNames.Sub, id.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, id.ToString()),
            new(ClaimTypes.Role, roleName)
        };

        var jwt = new JwtSecurityToken(_issuer, _audience, claims, now, expires, _signingCredentials);
        var accessToken = _jwtSecurityTokenHandler.WriteToken(jwt);

        return new JwtDto
        {
            AccessToken = accessToken
        };
    }
}