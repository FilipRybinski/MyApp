using FeeTracker.Core.Repositories;
using FeeTracker.Domain.Purpose;
using FeeTracker.Infrastructure.DAL.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FeeTracker.Infrastructure.DAL.Repositories;

internal sealed class PostgresFeePurposeRepository(
    FeeTrackerDbContext feeTrackerDbContext,
    IMediator mediator) : IFeePurposeRepository
{
    public async Task CreateFeePurpose(FeePurpose purpose)
    {
        await feeTrackerDbContext.FeePurposes.AddAsync(purpose);
        await feeTrackerDbContext.SaveChangesAsync();
    }
       

    public async Task<List<FeePurpose>> GetFeePurposes(Guid? identityId) =>
        await feeTrackerDbContext.FeePurposes.Where(p => p.OwnerId == identityId).ToListAsync();

    public async Task MarkAsCompleted(Guid id)
    {
        var purpose = await feeTrackerDbContext.FeePurposes.FirstOrDefaultAsync(p => p.Id == id);
        purpose.MarkAsCompleted();
        await feeTrackerDbContext.SaveChangesAsync();
        
    }

    public async Task<List<Guid>> GetListOfParticipats(Guid id)
    {
        var purpose = await feeTrackerDbContext.FeePurposes.Include(p => p.Participants).FirstOrDefaultAsync(p => p.Id == id);
        return purpose.Participants.Select(e => e.ContributorId).ToList();
    }

    public async Task DeleteFeePurpose(Guid id)
    {
        var purpose = await feeTrackerDbContext.FeePurposes.FirstOrDefaultAsync(e => e.Id == id);
        feeTrackerDbContext.Remove(purpose);
        await feeTrackerDbContext.SaveChangesAsync();
    }
}