namespace Shared.Core.Configuration;

public sealed class RoutesConfiguration
{
    public QueueMailerRoutes QueueMailerRoutes { get; set; }
    public NotificationRoutes NotificationRoutes { get; set; }
}

public sealed class QueueMailerRoutes
{
     public string SendConfirmationEmail { get; set; }
     public string SendResetPasswordEmail { get; set; }
    
}

public sealed class NotificationRoutes
{
    
}