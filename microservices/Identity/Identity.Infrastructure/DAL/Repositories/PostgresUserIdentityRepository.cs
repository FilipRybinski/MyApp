using Identity.Application.Security;
using Identity.Core.Entities;
using Identity.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.DAL.Repositories;

internal sealed class PostgresUserIdentityRepository(
    IdentityDbContext dbContext,
    IHttpContextTokenService contextTokenService)
    : IUserIdentityRepository
{
    public async Task<_Identity?> GetSessionUserIdentityAsync() =>
        await dbContext.Identities.FirstOrDefaultAsync<_Identity>(u => u.Id == contextTokenService.ExtractUserIdentityIdentifier());

    public async Task<_Identity> AddUserIdentityAsync(_Identity user)
    {
        dbContext.Identities.Add(user);
        await dbContext.SaveChangesAsync();
        await dbContext.Entry(user).ReloadAsync();
        return user;
    }

    public async Task<_Identity?> GetUserIdentityByEmailAsync(string email) =>
        await dbContext.Identities.Include<_Identity, Role>(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);

    public bool IsEmailAlreadyExists(string email) => dbContext.Identities.Any<_Identity>(u => u.Email == email);

    public bool IsUserNameAlreadyExists(string username) => dbContext.Identities.Any<_Identity>(u => u.Username == username);
}