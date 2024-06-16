using MyApp.Core.DTO;

namespace MyApp.Application.Handlers.GetAvailableMembers;

public interface IGetAvailableMembersHandler
{
    Task<IEnumerable<HateoasUserDto>> HandleAsync();
}