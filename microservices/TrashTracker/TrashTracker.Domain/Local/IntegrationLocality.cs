using Shared.Domain.Abstractions;
using TrashTracker.Domain.Integrations;

namespace TrashTracker.Domain.Local;

public class IntegrationLocality : Entity
{
    public Guid AlertzyIntegrationId { get; set; }
    public Guid LocalityId { get; set; }

    public AlertzyIntegration AlertzyIntegration { get; set; } = null!;
    public Locality Locality { get; set; } = null!;
}