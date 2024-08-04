using MyApp.Core.DTO;

namespace MyApp.Application.Handlers.IsAuthorized;

public interface IAuthorizedHandler
{
    Task<UserDto?> HandleAsync();
}