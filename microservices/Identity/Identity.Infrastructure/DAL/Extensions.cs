using Identity.Core.Repositories;
using Identity.Infrastructure.DAL.Context;
using Identity.Infrastructure.DAL.Initializer;
using Identity.Infrastructure.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.DAL;

namespace Identity.Infrastructure.DAL;

internal static class Extensions
{
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterPostgres<IdentityDbContext>(configuration);
        services.AddHostedService<DatabaseInitializer>();
        services.AddScoped<IUserIdentityRepository, PostgresUserIdentityRepository>();
        services.AddScoped<IRoleRepository, PostgresRoleRepository>();
        return services;
    }
}