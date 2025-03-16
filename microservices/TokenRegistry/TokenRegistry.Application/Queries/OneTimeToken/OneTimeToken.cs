using Shared.Core.Abstractions;
using TokenRegistry.Core.DTO;

namespace TokenRegistry.Application.Queries.OneTimeToken;

public sealed record OneTimeToken() : IQuery<TokenDto>;
