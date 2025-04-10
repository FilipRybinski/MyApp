using Identity.Domain.Identity;
using Identity.Domain.Role;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.DAL.Context;

internal sealed class IdentityDbContext(DbContextOptions<IdentityDbContext> dbContextOptions)
    : DbContext(dbContextOptions)
{
    public DbSet<UserIdentity> Identities { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}