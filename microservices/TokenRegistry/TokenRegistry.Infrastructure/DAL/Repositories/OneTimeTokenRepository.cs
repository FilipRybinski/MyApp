using StackExchange.Redis;
using TokenRegistry.Core.Repositories;

namespace TokenRegistry.Infrastructure.DAL.Repositories;

internal sealed class OneTimeTokenRepository(IDatabase dbContext) : IOneTimeTokenRepository
{
    public Task<string> Retrieve(string token)
    {
        throw new NotImplementedException();
    }
}