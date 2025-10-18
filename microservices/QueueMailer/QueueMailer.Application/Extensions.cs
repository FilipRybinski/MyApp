using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using RequestClient;
using Shared.Application.CQRS;

namespace QueueMailer.Application;

public static class Extensions
{
    public static IServiceCollection AddQueueMailerApplication(this IServiceCollection services)
    {

        services.AddCQRS(Assembly.GetExecutingAssembly());
        services.AddRequestClient();
        return services;
    }
}