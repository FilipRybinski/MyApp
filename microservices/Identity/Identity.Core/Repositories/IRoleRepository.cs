using Identity.Domain.Role;

namespace Identity.Core.Repositories;

public interface IRoleRepository
{
    public Task<Role> GetDefaultRoleAsync();
}