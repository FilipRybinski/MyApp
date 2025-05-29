using Shared.Domain.Abstractions;

namespace FeeTracker.Domain.Contribution;

public class FeeContribution : Entity
{
    
    public Guid Id { get; private set; }
    public DateTime DueDate { get; private set; }
    public bool IsPaid { get; private set; }
    public DateTime? PaidAt { get; private set; }
    
    public void MarkAsPaid()
    {
        IsPaid = true;
        PaidAt = DateTime.UtcNow;
    }

    public void MarkAsUnpaid()
    {
        IsPaid = false;
        PaidAt = null;
    }
}