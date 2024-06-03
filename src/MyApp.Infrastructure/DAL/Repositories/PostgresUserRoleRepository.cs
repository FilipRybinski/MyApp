using Microsoft.EntityFrameworkCore;
using MyApp.Core.Dictionary;
using MyApp.Core.Entities;
using MyApp.Core.Repositories;

namespace MyApp.Infrastructure.DAL.Repositories;

internal sealed class PostgresUserRoleRepository : IUserRoleRepository
{
    private readonly MyAppDbContext _dbContext;

    public PostgresUserRoleRepository(MyAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Role> GetDefaultRoleAsync() => await _dbContext.Roles.FirstOrDefaultAsync(r => r.Name == UserRoleDictionary.User);
    
}