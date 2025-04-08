using Shared.Application.Abstractions.CQRS;
using TokenRegistry.Core.Abstractions;
using TokenRegistry.Core.Enums;

namespace TokenRegistry.Application.Queries.ValidateToken;

public sealed class ValidateToken() : TokenQuery, IQuery<bool>
{
    public string Token { get; set; }
    public TokenType TokenType { get; set; }
}