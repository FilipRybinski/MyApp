namespace Shared.Core.Configuration;

public sealed class RoutesConfiguration
{
    public string Host { get; set; }
    public QueueMailerRoutes QueueMailerRoutes { get; set; }
    public NotificationRoutes NotificationRoutes { get; set; }
    public TokenRegistryRoutes TokenRegistryRoutes { get; set; }
}

public sealed class QueueMailerRoutes
{
     public string PrepareConfirmationEmail { get; set; }
     public string HandleConfirmationEmailEvent { get; set; }
     public string PrepareActivationEmail { get; set; }
     public string HandleActivationEmailEvent { get; set; }
     public string PrepareResetPasswordEmail { get; set; }
     public string HandleResetPasswordEmailEvent { get; set; }
     
     public string PreparePasswordSubmissionEmail { get; set; }
     
     public string HandlePasswordSubmissionEvent { get; set; }
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