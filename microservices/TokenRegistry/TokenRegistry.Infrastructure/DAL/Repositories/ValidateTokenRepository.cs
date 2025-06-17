using Shared.Application.Commands.Token;
using Shared.Core.Enums;
using StackExchange.Redis;
using TokenRegistry.Core.Repositories;
using TokenRegistry.Infrastructure.DAL.Abstractions;

namespace TokenRegistry.Infrastructure.DAL.Repositories;

internal sealed class ValidateTokenRepository(IDatabase dbContext) : TokenRepository(dbContext), IValidateTokenRepository
{
    public async Task<bool> ValidateToken(TokenQuery query, string token,TokenType tokenType, CancellationToken cancellationToken) =>
       await IsTokenValidAsync(query, token, tokenType, cancellationToken);
 
}