using StackExchange.Redis;
using TokenRegistry.Core.Repositories;

namespace TokenRegistry.Infrastructure.DAL.Repositories;

internal sealed class MultiTimeTokenRepository(IDatabase dbContext) : IMultiTimeTokenRepository
{
    public Task<string> Retrieve(string token)
    {
        throw new NotImplementedException();
    }
}