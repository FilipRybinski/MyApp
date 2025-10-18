using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrashTracker.Domain.Waste;

namespace TrashTracker.Infrastructure.DAL.Configurations;

internal sealed class  WasteTypeConfiguration : IEntityTypeConfiguration<WasteType>
{
    public void Configure(EntityTypeBuilder<WasteType> builder)
    {
        builder.HasIndex(w => w.Name).IsUnique();
    }
}