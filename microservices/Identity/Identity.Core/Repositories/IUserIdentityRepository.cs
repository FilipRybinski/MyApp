using Identity.Domain.Identity;

namespace Identity.Core.Repositories;

public interface IUserIdentityRepository
{
    public Task<UserIdentity?> GetSessionUserIdentityAsync();
    public Task<UserIdentity> AddUserIdentityAsync(UserIdentity user);
    public Task<UserIdentity?> GetUserIdentityByEmailAsync(string email);
    public bool IsEmailAlreadyExists(string email);
    public bool IsUserNameAlreadyExists(string username);
}