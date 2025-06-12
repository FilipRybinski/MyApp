using FeeTracker.Core.Repositories;
using FeeTracker.Domain.PurposeOwner;
using FeeTracker.Infrastructure.DAL.Context;
using MediatR;

namespace FeeTracker.Infrastructure.DAL.Repositories;

internal sealed class PostgresFeePurposeOwnerRepository(
    FeeTrackerDbContext feeTrackerDbContext,
    IMediator mediator) : IFeePurposeOwnerRepository
{
    public bool IsFeePurposeOwnerAlreadyExist(Guid? identityId) => 
        feeTrackerDbContext.FeePurposeOwners.Any(o => o.Id == identityId);

    public async Task CreateFeePurposeOwner(FeePurposeOwner owner)
    {
         await feeTrackerDbContext.FeePurposeOwners.AddAsync(owner);
         await feeTrackerDbContext.SaveChangesAsync();
    }
      
    
}