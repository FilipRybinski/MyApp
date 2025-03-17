using TokenRegistry.Core.Abstractions;
using TokenRegistry.Core.DTO;
using TokenRegistry.Core.Enums;

namespace TokenRegistry.Core.Repositories.Shared;

public interface IRetrieveToken
{
    public Task<TokenDto> Retrieve(TokenQuery query, CancellationToken cancellationToken);
}