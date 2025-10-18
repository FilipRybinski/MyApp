using Shared.Application.Abstractions.CQRS;
using Shared.Application.Commands.Token;
using Shared.Core.DTO;
using Shared.Core.Enums;

namespace TokenRegistry.Application.Queries.OneTimeToken;

public sealed record OneTimeToken(Guid IdentityId, ResourceType ResourceType) : TokenQuery(IdentityId, ResourceType), IQuery<TokenDto>;
