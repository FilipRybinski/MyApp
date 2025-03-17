using Shared.Core.Abstractions;
using TokenRegistry.Core.DTO;
using TokenRegistry.Core.Repositories;

namespace TokenRegistry.Application.Queries.LimitedTimeToken;

public sealed class LimitedTimeTokenHandler(ILimitedTimeTokenRepository limitedTimeTokenRepository) : IQueryHandler<LimitedTimeQueryToken, TokenDto>
{
    public async Task<TokenDto> HandleAsync(LimitedTimeQueryToken query, CancellationToken cancellationToken) => 
        await limitedTimeTokenRepository.Retrieve(query, cancellationToken);
}