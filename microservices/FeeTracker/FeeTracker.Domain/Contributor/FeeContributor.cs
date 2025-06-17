using Shared.Domain.Abstractions;

namespace FeeTracker.Domain.Contributor;

public class FeeContributor : Entity
{
    public Guid Id { get; private set; }
}