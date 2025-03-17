using TokenRegistry.Core.Enums;

namespace TokenRegistry.Core.DTO;

public sealed class TokenDto
{
    public string Token { get; set; }
    public ResourceType ResourceType { get; set; }
}