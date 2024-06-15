using MyApp.Core.Entities;

namespace MyApp.Core.Repositories;

public interface IMemberRepository
{
    Task InviteMembers(IEnumerable<Guid> members);
    Task RemoveMembers(IEnumerable<Guid> members);
    Task<IEnumerable<User>> GetAvailableMembers();
    Task<IEnumerable<User>> GetMyTeamMembers();
    Task<IEnumerable<User>> FindAvailableMember(string name);
}