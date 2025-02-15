using Identity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.DAL.Configurations;

internal sealed class UserIdentityConfiguration : IEntityTypeConfiguration<_Identity>
{
    public void Configure(EntityTypeBuilder<_Identity> builder)
    {
    }
}