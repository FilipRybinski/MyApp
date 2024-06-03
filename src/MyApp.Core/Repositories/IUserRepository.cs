using MyApp.Core.Entities;

namespace MyApp.Core.Repositories;

public interface IUserRepository
{
    public Task<User> GetUserAsync(Guid id);
    public Task<IEnumerable<User>> GetUsersAsync();
    public Task AddUserAsync(User user);
    public Task<User> IsUserExists(string email);
}