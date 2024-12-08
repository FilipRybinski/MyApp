using Identity.Core.Entities;

namespace Identity.Core.Repositories;

public interface IUserIdentityRepository
{
    public Task<_Identity?> GetSessionUserIdentityAsync();
    public Task<_Identity> AddUserIdentityAsync(Entities._Identity user);
    public Task<_Identity?> GetUserIdentityByEmailAsync(string email);
    public bool IsEmailAlreadyExists(string email);
    public bool IsUserNameAlreadyExists(string username);
}