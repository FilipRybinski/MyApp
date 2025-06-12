using FeeTracker.Domain.Contributor;
using FeeTracker.Domain.Participant;
using FeeTracker.Domain.PurposeOwner;
using Shared.Domain.Abstractions;

namespace FeeTracker.Domain.Purpose;

public class FeePurpose : Entity
{
    private FeePurpose(){}
    public FeePurpose(string title, DateTime startDate, DateTime endDate,decimal amount, Guid? ownerId)
    {
        Id = Guid.NewGuid();
        Title = title;
        StartDate = startDate;
        EndDate = endDate;
        Amount = amount;
        CreatedAt = DateTime.UtcNow;
        OwnerId = (Guid)ownerId!;
        Participants = new List<FeeParticipant>();
    }
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsCompleted { get; private set; }
    public Guid OwnerId { get; private set; }
    public FeePurposeOwner Owner { get; private set; }
    public virtual ICollection<FeeParticipant> Participants { get; private set; }

    public void MarkAsCompleted()
    {
        this.IsCompleted = true;
    }
}