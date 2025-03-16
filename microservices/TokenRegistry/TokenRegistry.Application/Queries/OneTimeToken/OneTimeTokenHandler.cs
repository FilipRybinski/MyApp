using Shared.Core.Abstractions;
using TokenRegistry.Core.DTO;
using TokenRegistry.Core.Providers;
using TokenRegistry.Core.Repositories;

namespace TokenRegistry.Application.Queries.OneTimeToken;

public sealed class OneTimeTokenHandler(
    IOneTimeTokenRepository oneTimeTokenRepository,
    ITokenProvider tokenProvider
    ) : IQueryHandler<OneTimeToken, TokenDto>
{
    public Task<TokenDto> HandleAsync(OneTimeToken query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}