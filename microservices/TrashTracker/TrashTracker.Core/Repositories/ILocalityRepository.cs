using TrashTracker.Domain.Local;

namespace TrashTracker.Core.Repositories;

public interface ILocalityRepository
{
    public Task<Locality> EnsureExists(string localityName);
    public Task<Locality> GetByIdAsync(Guid localityId);
}