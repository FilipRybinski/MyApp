using RequestClient.DTO;

namespace RequestClient.Handler;

public interface IRequestHandler
{
    Task<RequestClientResponse<TResponse>> SendRequestAsync<TRequest, TResponse>(
        string url, 
        HttpMethod method,
        CancellationToken cancellationToken,
        TRequest? body = default) 
        where TRequest : class
        where TResponse : class;
}