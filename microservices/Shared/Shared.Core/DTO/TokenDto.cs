
using Shared.Core.Enums;

namespace Shared.Core.DTO;

public sealed class TokenDto
{
    public string Token { get; set; }
    public ResourceType ResourceType { get; set; }
}