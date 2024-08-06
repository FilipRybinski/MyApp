using Microsoft.EntityFrameworkCore;
using MyApp.Application.Security;
using MyApp.Core.Entities;
using MyApp.Core.Repositories;

namespace MyApp.Infrastructure.DAL.Repositories;

internal sealed class PostgresUserRepository : IUserRepository
{
    private readonly IHttpContextTokenService _contextTokenService;
    private readonly MyAppDbContext _dbContext;

    public PostgresUserRepository(MyAppDbContext dbContext, IHttpContextTokenService contextTokenService)
    {
        _dbContext = dbContext;
        _contextTokenService = contextTokenService;
    }

    public async Task<User?> GetSessionUserAsync() =>
        await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == _contextTokenService.ExtractUserIdentifier());

    public async Task<User> AddUserAsync(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        await _dbContext.Entry(user).ReloadAsync();
        return user;
    }

    public async Task<User?> GetUserByEmailAsync(string email) =>
        await _dbContext.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);

    public bool IsEmailAlreadyExists(string email) => _dbContext.Users.Any(u => u.Email == email);

    public bool IsUserNameAlreadyExists(string username) => _dbContext.Users.Any(u => u.Username == username);
}