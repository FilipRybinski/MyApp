using MyApp.Core.Entities;

namespace MyApp.Core.Repositories;

public interface IUserRepository
{
    public Task<User> GetUserAsync(Guid id);
    public Task<IEnumerable<User>> GetUsersAsync();
    public Task AddUserAsync(User user);
    public Task<User> IsUserExists(string email);
    public bool IsEmailAlreadyExists(string email);
    public bool IsUserNameAlreadyExists(string username);
    public Task<User> GetCurrentUser();
    public Task<IEnumerable<User>> GetUsersWithIdentifier(IEnumerable<Guid> identifiers);
}