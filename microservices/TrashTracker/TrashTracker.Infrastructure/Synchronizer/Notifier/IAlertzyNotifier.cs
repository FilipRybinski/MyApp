namespace TrashTracker.Infrastructure.Synchronizer.Notifier;

public interface IAlertzyNotifier
{
    public Task CheckUpcomingCollectionsAndNotifyAsync();
}