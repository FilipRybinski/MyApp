using TokenRegistry.Core.Enums;

namespace TokenRegistry.Core.Abstractions;

public abstract class TokenQuery
{
    public Guid IdentityId { get; set; }
    public ResourceType ResourceType { get; set; }
}