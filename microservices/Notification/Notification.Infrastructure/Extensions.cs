using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure;

namespace Notification.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        /*services.AddQueuesDefinition();
        services.AddRabbitMqWorker(configuration,
            services.BuildServiceProvider().GetRequiredService<IQueuesDefinition>().Definition);*/
        services.AddSharedInfrastructure(configuration);
        return services;
    }
}