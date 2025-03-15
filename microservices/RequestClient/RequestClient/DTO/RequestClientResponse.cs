using System.Net;

namespace RequestClient.DTO;

public sealed class RequestClientResponse<T> where T : class
{
    public HttpResponseMessage HttpResponse { get; set; }
    public T? DeserializedResponseBody { get; set; }
}