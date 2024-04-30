using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Repositories;
using MyApp.Infrastructure.DAL.Repositories;

namespace MyApp.Infrastructure.DAL;

internal static class Extensions
{
    public static IServiceCollection AddPostgres(this IServiceCollection services)
    {
        services.AddDbContext<MyAppDbContext>(db => db.UseNpgsql(""));
        services.AddScoped<IUserRepository, PostgresUserRepository>();
        return services;
    }
}