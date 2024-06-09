using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Core.Entities;

namespace MyApp.Infrastructure.DAL.Configurations;

internal class UserRoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasMany(u => u.Users).WithOne(u => u.Role);
    }
}