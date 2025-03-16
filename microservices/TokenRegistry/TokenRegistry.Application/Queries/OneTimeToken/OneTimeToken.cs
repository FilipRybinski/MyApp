using Shared.Core.Abstractions;
using TokenRegistry.Core.Abstractions;
using TokenRegistry.Core.DTO;

namespace TokenRegistry.Application.Queries.OneTimeToken;

public sealed class OneTimeToken() : TokenQuery, IQuery<TokenDto>;
