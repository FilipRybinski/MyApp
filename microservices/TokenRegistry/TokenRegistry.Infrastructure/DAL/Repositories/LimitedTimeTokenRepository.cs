using StackExchange.Redis;
using TokenRegistry.Core.Abstractions;
using TokenRegistry.Core.DTO;
using TokenRegistry.Core.Enums;
using TokenRegistry.Core.Repositories;
using TokenRegistry.Infrastructure.DAL.Abstractions;

namespace TokenRegistry.Infrastructure.DAL.Repositories;

internal sealed class LimitedTimeTokenRepository(IDatabase dbContext) : TokenRepository(dbContext), ILimitedTimeTokenRepository
{
    public async Task<TokenDto> Retrieve(TokenQuery query, CancellationToken cancellationToken)
    {
        var expiry = query.ResourceType switch
        {
            ResourceType.RefreshToken => TimeSpan.FromDays(7),
            _ => TimeSpan.FromDays(1)
        };
        
        return await GetTokenAsync(query, TokenType.LimitedTimeToken, cancellationToken, expiry);
    }
        
        
 
}