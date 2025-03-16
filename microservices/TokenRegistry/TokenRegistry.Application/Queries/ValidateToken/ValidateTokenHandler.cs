using Shared.Core.Abstractions;

namespace TokenRegistry.Application.Queries.ValidateToken;

public sealed class ValidateTokenHandler : IQueryHandler<ValidateToken, bool>
{
    public Task<bool> HandleAsync(ValidateToken query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}