namespace QueueMailer.Core.Abstractions;

public interface IMailboxHandler<in TCommand> where TCommand : class, IMailbox
{
    Task HandleAsync(TCommand command, CancellationToken cancellationToken);
}