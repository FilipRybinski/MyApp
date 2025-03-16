using StackExchange.Redis;
using TokenRegistry.Core.Repositories;

namespace TokenRegistry.Infrastructure.DAL.Repositories;

internal sealed class ValidateTokenRepository(IDatabase dbContext) : IValidateTokenRepository
{
    public async Task<bool> ValidateTokenAsync(string token)
    {
        throw new NotImplementedException();
    }
}