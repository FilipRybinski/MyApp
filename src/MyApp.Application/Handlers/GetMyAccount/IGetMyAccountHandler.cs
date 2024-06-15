using MyApp.Core.DTO;

namespace MyApp.Application.Handlers.GetMyAccount;

public interface IGetMyAccountHandler
{
    Task<UserDto> HandleAsync();
}