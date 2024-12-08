using Identity.Core.Dictionary;
using Identity.Core.Entities;
using Identity.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.DAL.Repositories;

internal sealed class PostgresRoleRepository : IRoleRepository
{
    private readonly IdentityDbContext _dbContext;

    public PostgresRoleRepository(IdentityDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Role> GetDefaultRoleAsync() => await _dbContext.Roles.FirstOrDefaultAsync(r => r.Name == UserRoleDictionary.User);
    
}