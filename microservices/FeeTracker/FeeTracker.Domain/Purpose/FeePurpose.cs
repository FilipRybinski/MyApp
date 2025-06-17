using FeeTracker.Core.Enums;
using FeeTracker.Domain.Contributor;
using Shared.Domain.Abstractions;

namespace FeeTracker.Domain.Purpose;

public class FeePurpose : Entity
{
    public FeePurpose(
        string name,
        FeeFrequency frequency,
        Guid creatorId,
        decimal amount,
        DateTime startDate,
        DateTime endDate,
        int? cycleDay = default,
        string? description = default)
    {
        Id = Guid.NewGuid();
        Name = name;
        Frequency = frequency;
        CreatorId = creatorId;
        Amount = amount;
        StartDate = startDate;
        EndDate = endDate;
        CycleDay = cycleDay;
        CreatedAt = DateTime.Now;
        Description = description;
    }
    
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public FeeFrequency Frequency { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public int? CycleDay { get; private set; }
    public decimal Amount { get; private set; }
    public bool IsClosed { get; private set; }
    public bool IsArchived { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Guid CreatorId { get; private set; }
    public virtual ICollection<FeeContributor> Contributors { get; private set; }
    
    public void CloseFeePurpose() => IsClosed = true;
    public void ArchiveFeePurpose() => IsArchived = true;
    public void UnarchiveFeePurpose() => IsArchived = false;
}