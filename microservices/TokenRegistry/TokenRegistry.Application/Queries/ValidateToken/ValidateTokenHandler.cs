using Shared.Core.Abstractions;
using TokenRegistry.Core.DTO;
using TokenRegistry.Core.Repositories;

namespace TokenRegistry.Application.Queries.ValidateToken;

public sealed class ValidateTokenHandler(IValidateTokenRepository validateTokenRepository) : IQueryHandler<ValidateToken, ValidateTokenDto>
{
    public async Task<ValidateTokenDto> HandleAsync(ValidateToken query, CancellationToken cancellationToken) =>
        new ValidateTokenDto()
        {
            IsValid = await validateTokenRepository.ValidateToken(query, query.Token, query.TokenType,
                cancellationToken)
        };
}