using Shared.Application.Commands.Token;
using Shared.Core.Enums;

namespace TokenRegistry.Core.Repositories;

public interface IValidateTokenRepository
{
    public Task<bool> ValidateToken(TokenQuery query, string token,TokenType tokenType, CancellationToken cancellationToken);
}