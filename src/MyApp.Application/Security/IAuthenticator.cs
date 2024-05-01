using MyApp.Application.DTO;

namespace MyApp.Application.Security;

public interface IAuthenticator
{
    JwtDto CreateToken(Guid id, string role);
}