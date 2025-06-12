using FeeTracker.Domain.Purpose;
using FeeTracker.Domain.PurposeOwner;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FeeTracker.Infrastructure.DAL.Configurations;

internal sealed class FeePurposeOwnerConfiguration : IEntityTypeConfiguration<FeePurposeOwner>
{

    public void Configure(EntityTypeBuilder<FeePurposeOwner> builder)
    {
        builder
            .HasMany(o => o.FeePurposes)
            .WithOne(o => o.Owner);
        
    }
}