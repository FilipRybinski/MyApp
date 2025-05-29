using Shared.Core.Enums;

namespace Shared.Application.Commands.Token;

public record TokenQuery(Guid IdentityId, ResourceType ResourceType);
