using Shared.Core.Abstractions;
using TokenRegistry.Core.DTO;

namespace TokenRegistry.Application.Queries.MultiTimeToken;

public sealed record MultiTimeToken() : IQuery<TokenDto>;