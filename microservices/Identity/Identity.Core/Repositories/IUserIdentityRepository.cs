using Identity.Domain.Identity;

namespace Identity.Core.Repositories;

public interface IUserIdentityRepository
{
    public Task<UserIdentity?> GetSessionUserIdentityAsync();
    public Task<UserIdentity?> GetUserIdentityByIdAsync(Guid id);
    public Task<UserIdentity> AddUserIdentityAsync(UserIdentity user);
    public Task<UserIdentity?> GetUserIdentityByEmailAsync(string email);
    public Task UserIdentityActivationAsync(UserIdentity userIdentity);
    public Task UserIdentityPasswordSubmissionAsync(UserIdentity userIdentity, string password);
    public bool IsEmailAlreadyExists(string email);
    public bool IsUserNameAlreadyExists(string username);
}