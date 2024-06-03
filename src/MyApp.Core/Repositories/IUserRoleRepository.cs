using MyApp.Core.Entities;

namespace MyApp.Core.Repositories;

public interface IUserRoleRepository
{
    public Task<Role> GetDefaultRoleAsync();
}