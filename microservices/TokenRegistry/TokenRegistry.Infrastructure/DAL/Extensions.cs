using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure;
using StackExchange.Redis;
using TokenRegistry.Core.Configuration;
using TokenRegistry.Core.Repositories;
using TokenRegistry.Infrastructure.DAL.Context;
using TokenRegistry.Infrastructure.DAL.Repositories;

namespace TokenRegistry.Infrastructure.DAL;

internal static class Extensions
{
    public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetOptions<RedisConfiguration>(nameof(RedisConfiguration));
        services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(options.Host));
        services.AddRedisDbContext();

        services.AddScoped<ILimitedTimeTokenRepository, LimitedTimeTokenRepository>();
        services.AddScoped<IMultiTimeTokenRepository, MultiTimeTokenRepository>();
        services.AddScoped<IOneTimeTokenRepository, OneTimeTokenRepository>();
        services.AddScoped<IValidateTokenRepository, ValidateTokenRepository>();
        return services;
    }
}