using FeeTracker.Domain.Purpose;

namespace FeeTracker.Core.Repositories;

public interface IFeePurposeRepository
{
    public Task CreateFeePurpose(FeePurpose purpose);
    public Task<List<FeePurpose>> GetFeePurposes(Guid? identityId);
    public Task MarkAsCompleted(Guid id);
    public Task<List<Guid>> GetListOfParticipats(Guid id);
    
    public Task DeleteFeePurpose(Guid id);
}