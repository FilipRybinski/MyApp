using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace QueueMailer.Infrastructure.DAL.Context;

internal sealed class QueueMailerDbContext(DbContextOptions<QueueMailerDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();
    }
}