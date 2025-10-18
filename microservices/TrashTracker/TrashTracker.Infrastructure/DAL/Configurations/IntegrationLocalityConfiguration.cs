using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrashTracker.Domain.Local;

namespace TrashTracker.Infrastructure.DAL.Configurations;

internal sealed class IntegrationLocalityConfiguration : IEntityTypeConfiguration<IntegrationLocality>
{
    public void Configure(EntityTypeBuilder<IntegrationLocality> builder)
    {
        builder.HasKey(i => new { i.LocalityId, i.AlertzyIntegrationId });
        builder.HasOne(i => i.AlertzyIntegration)
            .WithMany(a => a.IntegrationLocalities)
            .HasForeignKey(ul => ul.AlertzyIntegrationId);
        builder.HasOne(ul => ul.Locality)
            .WithMany()
            .HasForeignKey(ul => ul.LocalityId);
    }
}