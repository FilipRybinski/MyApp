using MyApp.Core.DTO;

namespace MyApp.Application.Security;

public interface IHttpContextTokenService
{
    Guid? ExtractUserIdentifier();
    void Set(JwtDto jwt);
    void Remove();
}