using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Core.Configuration;

namespace Shared.Infrastructure.DAL;

public static class Extensions
{
    public static IServiceCollection RegisterPostgres<T>(this IServiceCollection services, IConfiguration configuration) where T : DbContext
    {
        var options = configuration.GetOptions<PostgresConfiguration>(nameof(PostgresConfiguration));
        services.AddDbContext<T>(db => db.UseNpgsql(options.ConnectionString));
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        return services;
    }
}