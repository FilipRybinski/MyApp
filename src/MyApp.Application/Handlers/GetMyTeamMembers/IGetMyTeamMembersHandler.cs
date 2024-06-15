using MyApp.Core.DTO;

namespace MyApp.Application.Handlers.GetMyTeamMembers;

public interface IGetMyTeamMembersHandler
{
    Task<IEnumerable<UserDto>> HandleAsync();
}