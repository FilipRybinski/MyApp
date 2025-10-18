using TrashTracker.Domain.Waste;

namespace TrashTracker.Core.Repositories;

public interface IWasteTypeRepository
{
    public Task<WasteType> EnsureExists(string wasteTypeName);
    public Task<WasteType> GetByIdAsync(Guid wasteTypeId);
}