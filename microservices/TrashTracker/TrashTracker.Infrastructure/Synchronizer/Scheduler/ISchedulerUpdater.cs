using System.Threading.Tasks;

namespace TrashTracker.Infrastructure.Synchronizer.Scheduler;

internal interface ISchedulerUpdater
{
    public Task UpdateSchedulesAsync();
}