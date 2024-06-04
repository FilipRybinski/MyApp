using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Repositories;
using MyApp.Infrastructure.DAL.Repositories;

namespace MyApp.Infrastructure.DAL;

internal static class Extensions
{
    private const string SectionName = "database";
    public static IServiceCollection AddPostgres(this IServiceCollection services,IConfiguration configuration)
    {
        var options = configuration.GetOptions<PostgresOptions>(SectionName);
        services.AddDbContext<MyAppDbContext>(db => db.UseNpgsql(options.ConnectionString));
        services.AddHostedService<DatabaseInitializer>();
        services.AddScoped<IUserRepository, PostgresUserRepository>();
        services.AddScoped<IUserRoleRepository, PostgresUserRoleRepository>();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior",true);
        return services;
    }

    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var options = new T();
        var section = configuration.GetSection(sectionName);
        section.Bind(options);
        return options;
    }
}