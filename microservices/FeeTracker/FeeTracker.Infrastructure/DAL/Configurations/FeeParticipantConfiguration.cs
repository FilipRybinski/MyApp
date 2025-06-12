using FeeTracker.Domain.Participant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FeeTracker.Infrastructure.DAL.Configurations;

internal sealed class FeeParticipantConfiguration: IEntityTypeConfiguration<FeeParticipant>
{
    public void Configure(EntityTypeBuilder<FeeParticipant> builder)
    {
        
    }
}