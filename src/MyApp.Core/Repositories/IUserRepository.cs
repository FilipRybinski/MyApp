using MyApp.Core.Entities;

namespace MyApp.Core.Repositories;

public interface IUserRepository
{
    public Task<User?> GetUser();
    public Task AddUserAsync(User user);
    public bool IsEmailAlreadyExists(string email);
    public bool IsUserNameAlreadyExists(string username);
}