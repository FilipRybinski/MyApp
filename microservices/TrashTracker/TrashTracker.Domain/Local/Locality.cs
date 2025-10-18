using Shared.Domain.Abstractions;
using TrashTracker.Domain.Date;

namespace TrashTracker.Domain.Local;

public class Locality : Entity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<CollectionDate> CollectionDates { get; set; } = new List<CollectionDate>();
}