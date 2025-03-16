using Shared.Core.Abstractions;
using TokenRegistry.Core.Abstractions;
using TokenRegistry.Core.DTO;

namespace TokenRegistry.Application.Queries.LimitedTimeToken;

public sealed class LimitedTimeQueryToken() : TokenQuery, IQuery<TokenDto>;