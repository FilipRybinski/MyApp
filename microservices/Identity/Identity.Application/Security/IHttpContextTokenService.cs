using Identity.Core.DTO;

namespace Identity.Application.Security;

public interface IHttpContextTokenService
{
    Guid? ExtractUserIdentityIdentifier();
    void Set(JwtDto jwt);
    void Remove();
}