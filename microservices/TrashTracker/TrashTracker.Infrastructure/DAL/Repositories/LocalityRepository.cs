using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrashTracker.Core.Repositories;
using TrashTracker.Domain.Local;
using TrashTracker.Infrastructure.DAL.Context;

namespace TrashTracker.Infrastructure.DAL.Repositories;

internal class LocalityRepository(TrashTrackerDbContext dbContext) : ILocalityRepository
{
    public async Task<Locality> EnsureExists(string localityName)
    {
        var locality = await dbContext.Localities.FirstOrDefaultAsync(l => l.Name == localityName);
        
        if (locality != null) return locality;
        
        locality = new Locality { Name = localityName };
        dbContext.Localities.Add(locality);
        await dbContext.SaveChangesAsync();

        return locality;
    }

    public async Task<Locality> GetByIdAsync(Guid localityId) =>
        await dbContext.Localities.FirstOrDefaultAsync(l => l.Id == localityId);
}