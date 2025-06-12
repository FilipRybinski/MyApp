using FeeTracker.Core.Repositories;
using FeeTracker.Domain.Participant;
using FeeTracker.Infrastructure.DAL.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FeeTracker.Infrastructure.DAL.Repositories;

internal sealed class PostgresFeeParticipantRepository(
    FeeTrackerDbContext feeTrackerDbContext,
    IMediator mediator) : IFeeParticipantRepository
{

    public async Task AttachParticipant(List<FeeParticipant> feeParticipant)
    {
        await feeTrackerDbContext.FeeParticipants.AddRangeAsync(feeParticipant);
        await feeTrackerDbContext.SaveChangesAsync();
    }

    public async Task<List<FeeParticipant>> GetAllPurposeParticipantsDetails(Guid id) =>
        await feeTrackerDbContext.FeeParticipants.Include(i=>i.Contributor).Where(p => p.FeePurposeId == id).ToListAsync();

    public async Task MarkAsPaid(Guid id)
    {
        var result = await feeTrackerDbContext.FeeParticipants.FirstOrDefaultAsync(e => e.Id == id);
        result.MarkAsPaid();
        await feeTrackerDbContext.SaveChangesAsync();
    }
}