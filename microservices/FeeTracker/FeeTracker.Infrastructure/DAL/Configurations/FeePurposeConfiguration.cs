using FeeTracker.Domain.Purpose;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FeeTracker.Infrastructure.DAL.Configurations;

internal sealed class FeePurposeConfiguration : IEntityTypeConfiguration<FeePurpose>
{
    public void Configure(EntityTypeBuilder<FeePurpose> builder)
    {
        
    }
}