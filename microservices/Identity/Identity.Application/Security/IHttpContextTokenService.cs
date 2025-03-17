using Identity.Core.DTO;

namespace Identity.Application.Security;

public interface IHttpContextTokenService
{
    Guid? ExtractUserIdentityIdentifier();

    string RetrieveRefreshToken();
    Task Set(JwtDto jwt, Guid identityId);
    void Remove();
}