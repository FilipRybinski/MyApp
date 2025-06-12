using FeeTracker.Domain.Contributor;
using FeeTracker.Domain.Purpose;

namespace FeeTracker.Core.Repositories;

public interface IFeeContributorRepository
{
    public Task CreateContributor(FeeContributor contributor);
    
    public Task<List<FeeContributor>> GetContributors(Guid? identityId);
}