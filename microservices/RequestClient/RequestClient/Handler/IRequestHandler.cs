namespace RequestClient.Handler;

public interface IRequestHandler
{
    Task<TResponse?> SendRequestAsync<TRequest, TResponse>(string url, HttpMethod method, TRequest? body = default)  where TRequest : class;
}