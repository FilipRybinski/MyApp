using StackExchange.Redis;
using TokenRegistry.Core.Repositories;

namespace TokenRegistry.Infrastructure.DAL.Repositories;

internal sealed class LimitedTimeTokenRepository(IDatabase dbContext) : ILimitedTimeTokenRepository
{
    public Task<string> Retrieve(string token)
    {
        throw new NotImplementedException();
    }
}