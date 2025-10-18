using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrashTracker.Core.Repositories;
using TrashTracker.Domain.Waste;
using TrashTracker.Infrastructure.DAL.Context;

namespace TrashTracker.Infrastructure.DAL.Repositories;

internal class WasteTypeRepository(TrashTrackerDbContext dbContext) : IWasteTypeRepository
{
    public async Task<WasteType> EnsureExists(string wasteTypeName)
    {
        var wasteType = await dbContext.WasteTypes.FirstOrDefaultAsync(w => w.Name == wasteTypeName);
        
        if (wasteType != null) return wasteType;
        
        wasteType = new WasteType { Name = wasteTypeName };
        dbContext.WasteTypes.Add(wasteType);
        await dbContext.SaveChangesAsync();

        return wasteType;
    }

    public async Task<WasteType> GetByIdAsync(Guid wasteTypeId) =>
        await dbContext.WasteTypes.FirstOrDefaultAsync(w => w.Id == wasteTypeId);
}