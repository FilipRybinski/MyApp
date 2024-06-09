using Microsoft.EntityFrameworkCore;
using MyApp.Core.Entities;

namespace MyApp.Infrastructure.DAL;

internal sealed class MyAppDbContext : DbContext
{
    public MyAppDbContext(DbContextOptions<MyAppDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Team> Teams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}