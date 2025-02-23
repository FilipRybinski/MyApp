namespace RequestClient.Handler;

public interface IRequestHandler
{
    Task<TResponse> SendRequestAsync<TResponse>(string url, HttpMethod method);
    Task<TResponse> SendRequestAsync<TRequest, TResponse>(string url, HttpMethod method, TRequest body);
}