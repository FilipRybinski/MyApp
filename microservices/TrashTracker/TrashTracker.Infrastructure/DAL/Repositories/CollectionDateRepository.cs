using Microsoft.EntityFrameworkCore;
using TrashTracker.Core.Repositories;
using TrashTracker.Domain.Date;
using TrashTracker.Infrastructure.DAL.Context;

namespace TrashTracker.Infrastructure.DAL.Repositories;

internal class CollectionDateRepository(TrashTrackerDbContext dbContext) : ICollectionDateRepository
{
    public async Task EnsureExists(Guid localityId, Guid wasteTypeId, DateTime date)
    {
        bool exists = await dbContext.CollectionDates.AnyAsync(c =>
            c.LocalityId == localityId &&
            c.WasteTypeId == wasteTypeId &&
            c.Date == date);
        
        if (!exists)
        {
            dbContext.CollectionDates.Add(new CollectionDate
            {
                LocalityId = localityId,
                WasteTypeId = wasteTypeId,
                Date = date
            });
        }
    }

    public async Task<List<CollectionDate>> GetAllAsync() => await dbContext.CollectionDates.ToListAsync();
}