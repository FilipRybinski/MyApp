using StackExchange.Redis;
using TokenRegistry.Core.Abstractions;
using TokenRegistry.Core.DTO;
using TokenRegistry.Core.Enums;
using TokenRegistry.Core.Repositories;
using TokenRegistry.Infrastructure.DAL.Abstractions;

namespace TokenRegistry.Infrastructure.DAL.Repositories;

internal sealed class ValidateTokenRepository(IDatabase dbContext) : TokenRepository(dbContext), IValidateTokenRepository
{
    public async Task<bool> ValidateToken(TokenQuery query, string token,TokenType tokenType, CancellationToken cancellationToken) =>
       await IsTokenValidAsync(query, token, tokenType, cancellationToken);
 
}