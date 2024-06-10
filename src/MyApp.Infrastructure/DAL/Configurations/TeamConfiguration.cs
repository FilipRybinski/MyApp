using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Core.Entities;

namespace MyApp.Infrastructure.DAL.Configurations;

internal class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasOne(t => t.Owner)
            .WithOne(u => u.Team);

        builder.HasMany(t => t.Members)
            .WithOne(u => u.Team);

        builder.Property(t => t.OwnerId).IsRequired();
        builder.Property(t => t.Id).IsRequired();
        builder.Property(t => t.Name).IsRequired();
    }
}