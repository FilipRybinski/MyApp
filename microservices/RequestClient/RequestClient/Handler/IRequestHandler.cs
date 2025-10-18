using Shared.Core.Objects;

namespace RequestClient.Handler;

public interface IRequestHandler
{
    Task<Result> SendRequestAsync<TRequest>(
        string url,
        HttpMethod method,
        CancellationToken cancellationToken,
        TRequest? body = default)
        where TRequest : class;
    
    Task<Result<TResponse>> SendRequestAsync<TRequest, TResponse>(
        string url, 
        HttpMethod method,
        CancellationToken cancellationToken,
        TRequest? body = default) 
        where TRequest : class
        where TResponse : class;
}