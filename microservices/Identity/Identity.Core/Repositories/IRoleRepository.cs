using Identity.Domain.Roles;

namespace Identity.Core.Repositories;

public interface IRoleRepository
{
    public Task<Role> GetDefaultRoleAsync();
}