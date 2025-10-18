using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrashTracker.Domain.Local;

namespace TrashTracker.Infrastructure.DAL.Configurations;

internal sealed class LocalityConfiguration : IEntityTypeConfiguration<Locality>
{
    public void Configure(EntityTypeBuilder<Locality> builder)
    {
        builder.HasIndex(l => l.Name).IsUnique();
    }
}