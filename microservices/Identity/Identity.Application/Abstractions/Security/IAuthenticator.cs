using Identity.Core.DTO;

namespace Identity.Application.Abstractions.Security;

public interface IAuthenticator
{
    JwtDto CreateToken(Guid id, string role);
}