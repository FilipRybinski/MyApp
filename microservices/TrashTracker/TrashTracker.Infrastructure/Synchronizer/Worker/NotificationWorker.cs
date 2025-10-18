using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TrashTracker.Infrastructure.Synchronizer.Notifier;

namespace TrashTracker.Infrastructure.Synchronizer.Worker;

internal class NotificationWorker(
    ILogger<NotificationWorker> logger,
    IServiceScopeFactory scopeFactory
) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("⏰ NotificationWorker started.");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = scopeFactory.CreateScope();
                var notifier = scope.ServiceProvider.GetRequiredService<IAlertzyNotifier>();
                await notifier.CheckUpcomingCollectionsAndNotifyAsync();
                
                var now = DateTime.Now;
                var nextRun = GetNextRunTime(now);

                logger.LogInformation("🕒 Next check scheduled for: {NextRun}", nextRun);

                var delay = nextRun - now;
                if (delay > TimeSpan.Zero)
                    await Task.Delay(delay, stoppingToken);

                

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
            catch (TaskCanceledException)
            {
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "❌ Error occurred in NotificationWorker.");
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }

    private static DateTime GetNextRunTime(DateTime now)
    {
        var today10 = now.Date.AddHours(10);
        var today20 = now.Date.AddHours(20);

        if (now < today10) return today10;
        if (now < today20) return today20;

        return now.Date.AddDays(1).AddHours(10);
    }
}