namespace MyApp.Core.Repositories;

public interface IMemberRepository
{
    Task InviteMembers(IEnumerable<Guid> members);
    Task RemoveMembers(IEnumerable<Guid> members);
}