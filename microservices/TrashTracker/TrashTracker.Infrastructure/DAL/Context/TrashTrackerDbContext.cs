using Microsoft.EntityFrameworkCore;
using TrashTracker.Domain.Date;
using TrashTracker.Domain.Integrations;
using TrashTracker.Domain.Local;
using TrashTracker.Domain.Waste;

namespace TrashTracker.Infrastructure.DAL.Context;

internal sealed class TrashTrackerDbContext(DbContextOptions<TrashTrackerDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<CollectionDate> CollectionDates { get; set; }
    public DbSet<AlertzyIntegration> AlertzyIntegrations { get; set; }
    public DbSet<IntegrationLocality> IntegrationLocalities { get; set; }
    public DbSet<Locality> Localities { get; set; }
    public DbSet<WasteType> WasteTypes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}