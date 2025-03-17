namespace Identity.Application.Handlers.Token;

public interface IRefreshTokenHandler
{
    Task HandleAsync(CancellationToken cancellationToken);
}