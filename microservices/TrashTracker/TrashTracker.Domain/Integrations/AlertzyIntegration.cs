using Shared.Domain.Abstractions;
using TrashTracker.Domain.Local;

namespace TrashTracker.Domain.Integrations;

public class AlertzyIntegration : Entity
{
    public Guid Id { get; set; }
    public Guid? UserIdentityId { get; set; }
    public string AlertzyKey { get; set; } = string.Empty;
    public ICollection<IntegrationLocality> IntegrationLocalities { get; set; } = new List<IntegrationLocality>();
}