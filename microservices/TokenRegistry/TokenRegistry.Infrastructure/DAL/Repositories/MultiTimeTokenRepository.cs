using Shared.Application.Commands.Token;
using Shared.Core.DTO;
using Shared.Core.Enums;
using StackExchange.Redis;
using TokenRegistry.Core.Repositories;
using TokenRegistry.Infrastructure.DAL.Abstractions;

namespace TokenRegistry.Infrastructure.DAL.Repositories;

internal sealed class MultiTimeTokenRepository(IDatabase dbContext) : TokenRepository(dbContext), IMultiTimeTokenRepository
{
    public async Task<TokenDto> Retrieve(TokenQuery query, CancellationToken cancellationToken) =>
        await GetTokenAsync(query, TokenType.MultiTimeToken, cancellationToken);

}