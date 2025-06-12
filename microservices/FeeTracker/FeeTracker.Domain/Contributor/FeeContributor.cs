using FeeTracker.Domain.Participant;
using FeeTracker.Domain.PurposeOwner;
using Shared.Domain.Abstractions;

namespace FeeTracker.Domain.Contributor;

public class FeeContributor : Entity
{
    private FeeContributor() { }
    public FeeContributor(string name,string surname,string email)
    {
        Id = Guid.NewGuid();
        Name = name;
        Surname = surname;
        Email = email;
    }
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Email { get; private set; }

    public virtual ICollection<FeeParticipant> FeeParticipants { get; private set; } = new List<FeeParticipant>();
}