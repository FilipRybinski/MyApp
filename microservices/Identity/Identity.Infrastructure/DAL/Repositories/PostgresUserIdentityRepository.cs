using Identity.Application.Security;
using Identity.Core.Entities;
using Identity.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.DAL.Repositories;

internal sealed class PostgresUserIdentityRepository : IUserIdentityRepository
{
    private readonly IHttpContextTokenService _contextTokenService;
    private readonly IdentityDbContext _dbContext;

    public PostgresUserIdentityRepository(IdentityDbContext dbContext, IHttpContextTokenService contextTokenService)
    {
        _dbContext = dbContext;
        _contextTokenService = contextTokenService;
    }

    public async Task<_Identity?> GetSessionUserIdentityAsync() =>
        await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync<_Identity>(_dbContext.Identities, u => u.Id == _contextTokenService.ExtractUserIdentityIdentifier());

    public async Task<_Identity> AddUserIdentityAsync(_Identity user)
    {
        _dbContext.Identities.Add(user);
        await _dbContext.SaveChangesAsync();
        await _dbContext.Entry(user).ReloadAsync();
        return user;
    }

    public async Task<_Identity?> GetUserIdentityByEmailAsync(string email) =>
        await EntityFrameworkQueryableExtensions.Include<_Identity, Role>(_dbContext.Identities, u => u.Role).FirstOrDefaultAsync(u => u.Email == email);

    public bool IsEmailAlreadyExists(string email) => Queryable.Any<_Identity>(_dbContext.Identities, u => u.Email == email);

    public bool IsUserNameAlreadyExists(string username) => Queryable.Any<_Identity>(_dbContext.Identities, u => u.Username == username);
}