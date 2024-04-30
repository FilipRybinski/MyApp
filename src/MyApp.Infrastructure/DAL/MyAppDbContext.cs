
using Microsoft.EntityFrameworkCore;

namespace MyApp.Infrastructure.DAL;

internal sealed class MyAppDbContext : DbContext
{

    public MyAppDbContext(DbContextOptions<MyAppDbContext> dbContextOptions) : base(dbContextOptions)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}