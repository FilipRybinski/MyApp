namespace QueueMailer.Core.Configuration;

public sealed class MailboxConfiguration
{
    public string Host { get; set; }
    public int Port { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}