using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Shared.Core.Exceptions;

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
            CustomException => (StatusCodes.Status400BadRequest, new Error(exception
                .GetType().Name.Replace("Exception", string.Empty), exception.Message)),
            _ => (StatusCodes.Status500InternalServerError, new Error("Error", "There was an error"))
        };

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(error);
    }

    private record Error(string Code, string Reason);
}