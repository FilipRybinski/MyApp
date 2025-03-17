namespace Shared.Core.Configuration;

public sealed class RoutesConfiguration
{
    public QueueMailerRoutes QueueMailerRoutes { get; set; }
    public NotificationRoutes NotificationRoutes { get; set; }
    public TokenRegistryRoutes TokenRegistryRoutes { get; set; }
}

public sealed class QueueMailerRoutes
{
     public string SendConfirmationEmail { get; set; }
     public string SendResetPasswordEmail { get; set; }
    
}

public sealed class NotificationRoutes
{
    
}

public sealed class TokenRegistryRoutes
{
    public string RequestOneTimeToken { get; set; }
    public string RequestMultiTimeToken { get; set; }
    public string RequestLimitedTimeToken { get; set; }
    public string ValidateToken { get; set; }
}