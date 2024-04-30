using MyApp.Application.Abstractions;
using MyApp.Application.Queries;

public sealed class LogInHandler : IQueryHandler<LogIn,bool>
{
    public Task<bool> HandleAsync(LogIn query)
    {
        throw new NotImplementedException();
    }
}