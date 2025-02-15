using Identity.Core.Dictionary;
using Identity.Core.Entities;
using Identity.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.DAL.Repositories;

internal sealed class PostgresRoleRepository(IdentityDbContext dbContext) : IRoleRepository
{
    public async Task<Role> GetDefaultRoleAsync() => await dbContext.Roles.FirstOrDefaultAsync(r => r.Name == UserRoleDictionary.User);
    
}