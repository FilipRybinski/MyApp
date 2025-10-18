using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Shared.Application.CQRS;

namespace TrashTracker.Application;

public static class Extensions
{
    public static IServiceCollection AddTrashTrackerApplication(this IServiceCollection services)
    {
        services.AddCQRS(Assembly.GetExecutingAssembly());
        
        return services;
    }
}