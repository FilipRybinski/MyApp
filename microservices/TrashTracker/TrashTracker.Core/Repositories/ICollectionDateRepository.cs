using TrashTracker.Domain.Date;

namespace TrashTracker.Core.Repositories;

public interface ICollectionDateRepository
{
    public Task EnsureExists(Guid localityId, Guid wasteTypeId, DateTime date);
    public Task<List<CollectionDate>> GetAllAsync();
}