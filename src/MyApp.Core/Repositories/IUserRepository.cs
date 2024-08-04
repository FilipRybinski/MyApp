using MyApp.Core.Entities;

namespace MyApp.Core.Repositories;

public interface IUserRepository
{
    public Task<User?> GetSessionUserAsync();
    public Task<User> AddUserAsync(User user);
    public Task<User?> GetUserByEmailAsync(string email);
    public bool IsEmailAlreadyExists(string email);
    public bool IsUserNameAlreadyExists(string username);
}