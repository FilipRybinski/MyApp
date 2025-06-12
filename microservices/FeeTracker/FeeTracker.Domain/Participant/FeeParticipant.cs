using FeeTracker.Domain.Contributor;
using FeeTracker.Domain.Purpose;
using Shared.Domain.Abstractions;

namespace FeeTracker.Domain.Participant;

public class FeeParticipant : Entity
{
    public FeeParticipant(Guid feePurposeId,Guid contributorId)
    {
        Id = Guid.NewGuid();
        FeePurposeId = feePurposeId;
        ContributorId = contributorId;
        HasPaid = false;
        AddedAt = DateTime.Now;
    }
    
    public Guid Id { get; private set; }
    public Guid FeePurposeId { get; private set; }
    public virtual FeePurpose FeePurpose { get; private set; }
    public Guid ContributorId { get; private set; }
    public virtual FeeContributor Contributor { get; private set; }
    public bool HasPaid { get; set; }
    public DateTime AddedAt { get; set; }

    public void MarkAsPaid()
    {
        HasPaid = true;
    }

}