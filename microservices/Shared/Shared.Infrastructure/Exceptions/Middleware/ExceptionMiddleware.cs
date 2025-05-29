using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Shared.Core.Exceptions;
using Shared.Core.Objects;

namespace Shared.Infrastructure.Exceptions.Middleware;

internal sealed class ExceptionMiddleware(ILogger<ExceptionMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(e, context);
        }
    }

    private async Task HandleExceptionAsync(Exception exception, HttpContext context)
    {
        logger.LogError(exception, "Exception thrown while processing request at {Path}", context.Request?.Path);
        var (statusCode, error) = exception switch
        {
            CustomException => (StatusCodes.Status400BadRequest, Result.Failure(Error.BadRequest($"{exception
                .GetType().Name.Replace("Exception", string.Empty)} - ${exception.Message}"))),
            _ => (StatusCodes.Status500InternalServerError, Result.Failure(Error.InternalServerError("Internal Server Error")))
        };

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(error);
    }

}