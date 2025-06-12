using FeeTracker.Core.Repositories;
using FeeTracker.Domain.Contributor;
using FeeTracker.Infrastructure.DAL.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FeeTracker.Infrastructure.DAL.Repositories;

internal class PostgresFeeContributorRepository(
    FeeTrackerDbContext feeTrackerDbContext,
    IMediator mediator) : IFeeContributorRepository
{
    public async Task CreateContributor(FeeContributor contributor)
    {
           await feeTrackerDbContext.FeeContributors.AddAsync(contributor);
           await ExecuteContributorDomainEvent(contributor);
           await feeTrackerDbContext.SaveChangesAsync();
    }

    public async Task<List<FeeContributor>> GetContributors(Guid? identityId) =>
        await feeTrackerDbContext.FeeContributors.ToListAsync();

    
    private async Task ExecuteContributorDomainEvent(FeeContributor contributory)
    {
        foreach (var domainEvent in contributory.DomainEvents)
        {
            await mediator.Publish(domainEvent);
        }
        contributory.DomainEvents.Clear();
    }
}