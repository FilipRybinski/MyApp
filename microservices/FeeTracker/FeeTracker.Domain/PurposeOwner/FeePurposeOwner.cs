using FeeTracker.Domain.Contributor;
using FeeTracker.Domain.Purpose;

namespace FeeTracker.Domain.PurposeOwner;

public class FeePurposeOwner
{
    private FeePurposeOwner(){}
    public FeePurposeOwner(Guid? identityId)
    {
        Id = (Guid)identityId!;
        FeePurposes = new List<FeePurpose>();
    }
    public Guid Id { get; set; }
    public ICollection<FeePurpose> FeePurposes { get; set; }
}