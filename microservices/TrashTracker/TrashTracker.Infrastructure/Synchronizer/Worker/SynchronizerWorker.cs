using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TrashTracker.Core.Scheduler;
using TrashTracker.Infrastructure.Synchronizer.Scheduler;

namespace TrashTracker.Infrastructure.Synchronizer.Worker;

internal sealed class SynchronizerWorker(
    ILogger<SynchronizerWorker> logger,
    IServiceScopeFactory scopeFactory
    ) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("SynchronizerService started.");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = scopeFactory.CreateScope();
                var schedulerUpdater = scope.ServiceProvider.GetRequiredService<ISchedulerUpdater>();
                await schedulerUpdater.UpdateSchedulesAsync();
                
                var now = DateTime.Now;
                var nextRun = SchedulerHelper.GetNextRunTime(now);
                var delay = nextRun - now;
                
                logger.LogInformation("Next synchronization at: {NextRun}", nextRun);
                
                await Task.Delay(delay, stoppingToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error during schedule synchronization.");
            }
        }
    }
}