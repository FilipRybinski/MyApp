using FeeTracker.Domain.PurposeOwner;

namespace FeeTracker.Core.Repositories;

public interface IFeePurposeOwnerRepository
{
    public bool IsFeePurposeOwnerAlreadyExist(Guid? identityId);
    public Task CreateFeePurposeOwner(FeePurposeOwner owner);
}