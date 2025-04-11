using System.Net;
using Shared.Core.Enums;

namespace Shared.Core.Objects;

public record Error
{
    public HttpStatusCode StatusCode { get; }
    public string Code { get; }
    public string Description { get; }
    public ErrorType Type { get; }
    public IEnumerable<ErrorDetails>? ErrorDetails { get; }
    public Error(HttpStatusCode statusCode, string description, ErrorType type, IEnumerable<ErrorDetails>? errorDetails)
    {
        StatusCode = statusCode;
        Code = type.ToString();
        Description = description;
        Type = type;
        ErrorDetails = errorDetails;
    }
    public static Error BadRequest(string description, IEnumerable<ErrorDetails>? errorDetails = default) =>
        new(HttpStatusCode.BadRequest, description, ErrorType.BadRequest, errorDetails);

    public static Error Unauthorized(string description, IEnumerable<ErrorDetails>? errorDetails = default) =>
        new(HttpStatusCode.Unauthorized, description, ErrorType.Unauthorized, errorDetails);

    public static Error Forbidden(string description, IEnumerable<ErrorDetails>? errorDetails = default) =>
        new(HttpStatusCode.Forbidden,description ,ErrorType.Forbidden, errorDetails);

    public static Error NotFound(string description, IEnumerable<ErrorDetails>? errorDetails = default) =>
        new(HttpStatusCode.NotFound, description, ErrorType.NotFound, errorDetails);

    public static Error Conflict(string description, IEnumerable<ErrorDetails>? errorDetails = default) =>
        new(HttpStatusCode.Conflict, description, ErrorType.Conflict, errorDetails);

    public static Error InternalServerError( string description, IEnumerable<ErrorDetails>? errorDetails = default) =>
        new(HttpStatusCode.InternalServerError, description, ErrorType.InternalServerError, errorDetails);

    public static Error Timeout(string description, IEnumerable<ErrorDetails>? errorDetails = default) =>
        new(HttpStatusCode.RequestTimeout, description, ErrorType.Timeout, errorDetails);
}