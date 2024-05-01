using MyApp.Application.DTO;

namespace MyApp.Application.Security;

public interface ITokenStorage
{
    void Set(JwtDto jwt);
    JwtDto Get();
}