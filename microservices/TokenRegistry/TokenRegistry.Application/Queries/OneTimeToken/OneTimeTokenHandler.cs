using Shared.Core.Abstractions;
using TokenRegistry.Core.DTO;
using TokenRegistry.Core.Repositories;

namespace TokenRegistry.Application.Queries.OneTimeToken;

public sealed class OneTimeTokenHandler(IOneTimeTokenRepository oneTimeTokenRepository) : IQueryHandler<OneTimeToken, TokenDto>
{
    public async Task<TokenDto> HandleAsync(OneTimeToken query, CancellationToken cancellationToken) =>
        await oneTimeTokenRepository.Retrieve(query, cancellationToken);
}