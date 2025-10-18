namespace TrashTracker.Core.Scheduler;

public static class SchedulerHelper
{
    public static DateTime GetNextRunTime(DateTime now)
    {
        var today = now.Date.AddHours(3);
        return now < today ? today : today.AddDays(1);
    }
}