using Microsoft.EntityFrameworkCore;
using MyApp.Application.Security;
using MyApp.Core.Entities;
using MyApp.Core.Repositories;

namespace MyApp.Infrastructure.DAL.Repositories;

internal sealed class PostgresUserRepository : IUserRepository
{
    private readonly IHttpContextTokenStorage _contextTokenStorage;
    private readonly MyAppDbContext _dbContext;

    public PostgresUserRepository(MyAppDbContext dbContext, IHttpContextTokenStorage contextTokenStorage)
    {
        _dbContext = dbContext;
        _contextTokenStorage = contextTokenStorage;
    }

    public async Task<User?> GetUser() =>
        await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == _contextTokenStorage.GetUserIdentifier());

    public async Task AddUserAsync(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
    }

    public bool IsEmailAlreadyExists(string email) => _dbContext.Users.Any(u => u.Email == email);

    public bool IsUserNameAlreadyExists(string username) => _dbContext.Users.Any(u => u.Username == username);
}