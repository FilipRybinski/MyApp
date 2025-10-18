using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrashTracker.Core.Configuration;
using TrashTracker.Infrastructure.Synchronizer.Notifier;
using TrashTracker.Infrastructure.Synchronizer.Scheduler;
using TrashTracker.Infrastructure.Synchronizer.Worker;

namespace TrashTracker.Infrastructure.Synchronizer;

internal static class Extensions
{
    public static IServiceCollection AddSynchronizer(this IServiceCollection services,IConfiguration configuration)
    {
        services.Configure<TrashTrackerConfiguration>(configuration.GetRequiredSection(nameof(TrashTrackerConfiguration)));
        services.Configure<AlertzyConfiguration>(configuration.GetRequiredSection(nameof(AlertzyConfiguration)));
        services.AddScoped<ISchedulerUpdater, SchedulerUpdater>();
        services.AddScoped<IAlertzyNotifier, AlertzyNotifier>();
        services.AddHostedService<NotificationWorker>();
        services.AddHostedService<SynchronizerWorker>();
        return services;
    }
}