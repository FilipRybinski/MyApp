namespace MyApp.Application.Abstractions;

public interface IEmptyQueryHandler<TResult> where TResult : class
{
    Task<TResult> HandleAsync();
}