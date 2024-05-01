using Microsoft.EntityFrameworkCore;
using MyApp.Core.Entities;
using MyApp.Core.Repositories;

namespace MyApp.Infrastructure.DAL.Repositories;

internal sealed class PostgresUserRepository : IUserRepository
{
    private readonly MyAppDbContext _dbContext;

    public PostgresUserRepository(MyAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> GetUserAsync(Guid id) =>await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
    public async Task<IEnumerable<User>> GetUsersAsync() => await _dbContext.Users.ToListAsync();
    public async Task AddUserAsync(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
    }
}