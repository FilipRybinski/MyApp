using Shared.Core.Abstractions;
using TokenRegistry.Core.DTO;

namespace TokenRegistry.Application.Queries.LimitedTimeToken;

public sealed record LimitedTimeToken() : IQuery<TokenDto>;