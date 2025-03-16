using Shared.Core.Abstractions;
using TokenRegistry.Core.DTO;

namespace TokenRegistry.Application.Queries.ValidateToken;

public sealed record ValidateToken() : IQuery<bool>;