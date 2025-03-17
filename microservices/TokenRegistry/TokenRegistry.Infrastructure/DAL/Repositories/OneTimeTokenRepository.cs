using StackExchange.Redis;
using TokenRegistry.Core.Abstractions;
using TokenRegistry.Core.DTO;
using TokenRegistry.Core.Enums;
using TokenRegistry.Core.Repositories;
using TokenRegistry.Infrastructure.DAL.Abstractions;

namespace TokenRegistry.Infrastructure.DAL.Repositories;

internal sealed class OneTimeTokenRepository(IDatabase dbContext) : TokenRepository(dbContext), IOneTimeTokenRepository
{
    public async Task<TokenDto> Retrieve(TokenQuery query, CancellationToken cancellationToken) =>
        await GetTokenAsync(query, TokenType.OneTimeToken, cancellationToken);
    
}