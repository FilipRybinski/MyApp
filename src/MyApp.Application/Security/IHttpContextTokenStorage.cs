using MyApp.Core.DTO;

namespace MyApp.Application.Security;

public interface IHttpContextTokenStorage
{
    Guid? GetUserIdentifier();
    void Set(JwtDto jwt);
    void Remove();
}