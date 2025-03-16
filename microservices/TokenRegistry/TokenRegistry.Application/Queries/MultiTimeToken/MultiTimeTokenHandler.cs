using Shared.Core.Abstractions;
using TokenRegistry.Core.DTO;
using TokenRegistry.Core.Repositories;

namespace TokenRegistry.Application.Queries.MultiTimeToken;

public sealed class MultiTimeTokenHandler(IMultiTimeTokenRepository multiTimeTokenRepository) : IQueryHandler<MultiTimeToken, TokenDto>
{
    public async Task<TokenDto> HandleAsync(MultiTimeToken query, CancellationToken cancellationToken) => 
        await multiTimeTokenRepository.Retrieve(query, cancellationToken);
}