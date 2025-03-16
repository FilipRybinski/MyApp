using Shared.Core.Abstractions;
using TokenRegistry.Core.Repositories;

namespace TokenRegistry.Application.Queries.ValidateToken;

public sealed class ValidateTokenHandler(IValidateTokenRepository validateTokenRepository) : IQueryHandler<ValidateToken, bool>
{
    public async Task<bool> HandleAsync(ValidateToken query, CancellationToken cancellationToken) =>
        await validateTokenRepository.ValidateToken(query, query.Token, query.TokenType, cancellationToken);
}