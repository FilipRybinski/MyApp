using Shared.Application.Abstractions.CQRS;
using Shared.Core.DTO;
using Shared.Core.Enums;

namespace Shared.Application.Commands.Token;

public sealed record ValidateToken(
    Guid IdentityId,
    ResourceType ResourceType,
    string Token,
    TokenType TokenType
    ) : TokenQuery(IdentityId, ResourceType), IQuery<TokenValidationDto>;