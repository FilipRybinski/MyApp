using FeeTracker.Domain.Contributor;
using FeeTracker.Domain.Participant;
using FeeTracker.Domain.Purpose;
using FeeTracker.Domain.PurposeOwner;
using Microsoft.EntityFrameworkCore;

namespace FeeTracker.Infrastructure.DAL.Context;

internal sealed class FeeTrackerDbContext(DbContextOptions<FeeTrackerDbContext> dbContextOptions)
    : DbContext(dbContextOptions)
{
    public DbSet<FeePurposeOwner> FeePurposeOwners { get; set; }
    public DbSet<FeeContributor> FeeContributors { get; set; }
    public DbSet<FeePurpose> FeePurposes { get; set; }
    public DbSet<FeeParticipant> FeeParticipants{ get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}