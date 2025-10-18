using Shared.Domain.Abstractions;
using TrashTracker.Domain.Local;
using TrashTracker.Domain.Waste;

namespace TrashTracker.Domain.Date;

public class CollectionDate : Entity
{
    public Guid Id { get; set; }
    public Guid LocalityId { get; set; }
    public Locality Locality { get; set; } = null!;
    public Guid WasteTypeId { get; set; }
    public WasteType WasteType { get; set; } = null!;
    public DateTime Date { get; set; }
}