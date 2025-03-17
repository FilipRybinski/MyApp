using Shared.Core.Abstractions;
using TokenRegistry.Core.Abstractions;
using TokenRegistry.Core.DTO;
using TokenRegistry.Core.Enums;

namespace TokenRegistry.Application.Queries.ValidateToken;

public sealed class ValidateToken() : TokenQuery, IQuery<ValidateTokenDto>
{
    public string Token { get; set; }
    public TokenType TokenType { get; set; }
}