using MyApp.Core.DTO;

namespace MyApp.Application.Security;

public interface IHttpContextTokenStorage
{
    Guid? GetCurrentUserIdentifier();
    void Set(JwtDto jwt);
    void Remove();
}