using Identity.Core.DTO;

namespace Identity.Application.Security;

public interface IAuthenticator
{
    JwtDto CreateToken(Guid id, string role);
}