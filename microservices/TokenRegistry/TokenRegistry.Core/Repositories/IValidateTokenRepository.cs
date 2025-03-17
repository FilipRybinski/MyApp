using TokenRegistry.Core.Abstractions;
using TokenRegistry.Core.DTO;
using TokenRegistry.Core.Enums;
using TokenRegistry.Core.Repositories.Shared;

namespace TokenRegistry.Core.Repositories;

public interface IValidateTokenRepository
{
    public Task<bool> ValidateToken(TokenQuery query, string token,TokenType tokenType, CancellationToken cancellationToken);
}