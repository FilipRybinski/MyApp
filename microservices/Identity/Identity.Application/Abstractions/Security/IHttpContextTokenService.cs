using Identity.Core.DTO;

namespace Identity.Application.Abstractions.Security;

public interface IHttpContextTokenService
{
    void Set(JwtDto jwt);
    void Remove();
}