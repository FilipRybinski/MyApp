using Identity.Core.Entities;

namespace Identity.Core.Repositories;

public interface IRoleRepository
{
    public Task<Role> GetDefaultRoleAsync();
}