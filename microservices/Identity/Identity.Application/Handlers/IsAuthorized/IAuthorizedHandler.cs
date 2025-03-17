using Identity.Core.DTO;

namespace Identity.Application.Handlers.IsAuthorized;

public interface IAuthorizedHandler
{
    Task<IdentityDto?> HandleAsync(CancellationToken cancellationToken);
}