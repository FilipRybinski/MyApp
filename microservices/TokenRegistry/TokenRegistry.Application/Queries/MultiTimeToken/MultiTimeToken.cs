using Shared.Core.Abstractions;
using TokenRegistry.Core.Abstractions;
using TokenRegistry.Core.DTO;

namespace TokenRegistry.Application.Queries.MultiTimeToken;

public sealed class MultiTimeToken() : TokenQuery, IQuery<TokenDto>;