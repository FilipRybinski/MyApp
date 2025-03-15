using Identity.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.DAL.Context;

internal sealed class IdentityDbContext(DbContextOptions<IdentityDbContext> dbContextOptions)
    : DbContext(dbContextOptions)
{
    public DbSet<_Identity> Identities { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}