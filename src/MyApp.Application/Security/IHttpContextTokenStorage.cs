using MyApp.Application.DTO;

namespace MyApp.Application.Security;

public interface IHttpContextTokenStorage
{
    Guid? GetCurrentUserIdentifier();
    void Set(JwtDto jwt);
}