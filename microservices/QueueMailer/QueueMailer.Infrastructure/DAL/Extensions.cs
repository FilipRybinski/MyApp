using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QueueMailer.Core.Repositories;
using QueueMailer.Infrastructure.DAL.Context;
using QueueMailer.Infrastructure.DAL.Initializer;
using QueueMailer.Infrastructure.DAL.Repositories;
using Shared.Infrastructure.DAL;

namespace QueueMailer.Infrastructure.DAL;

internal static class Extensions
{
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterPostgres<QueueMailerDbContext>(configuration);
        services.AddScoped<IQueueMailerOutBoxRepository, QueueMailerOutBoxRepository>();
        services.AddHostedService<DatabaseInitializer>();
        return services;
    }
}