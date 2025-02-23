using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Application;
using Shared.Core.Options;

namespace Shared.Infrastructure.DAL;

public static class Extensions
{
    private const string SectionName = "database";
    public static IServiceCollection RegisterPostgres<T>(this IServiceCollection services, IConfiguration configuration) where T : DbContext
    {
        var options = configuration.GetOptions<PostgresOptions>(SectionName);
        services.AddDbContext<T>(db => db.UseNpgsql(options.ConnectionString));
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        return services;
    }
}