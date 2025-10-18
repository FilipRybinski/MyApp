using Shared.Application.Abstractions.CQRS;
using Shared.Application.Commands.Token;
using Shared.Core.DTO;
using Shared.Core.Enums;

namespace TokenRegistry.Application.Queries.MultiTimeToken;

public sealed record MultiTimeToken(Guid IdentityId, ResourceType ResourceType) : TokenQuery(IdentityId, ResourceType), IQuery<TokenDto>;