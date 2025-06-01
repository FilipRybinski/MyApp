using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace QueueMailer.Api.Aspects;

[PSerializable]
public class LogExecutionTimeAttribute : OnMethodBoundaryAspect
{
    private Stopwatch _stopwatch;

    public override void OnEntry(MethodExecutionArgs args)
        => _stopwatch = Stopwatch.StartNew();

    public override void OnExit(MethodExecutionArgs args)
    {
        _stopwatch.Stop();

        if (GetHttpContext(args.Instance) is not { } context)
            return;

        var request = context.Request;
        var method = request.Method;
        var path = request.Path;

        var logger = context.RequestServices.GetService<ILogger<LogExecutionTimeAttribute>>();
        logger?.LogInformation("Endpoint {Method} {Path} executed in {Elapsed} ms",
            method, path, _stopwatch.ElapsedMilliseconds);
    }

    private static HttpContext? GetHttpContext(object instance) =>
        instance is ControllerBase controller
            ? controller.HttpContext
            : instance.GetType().GetProperty("HttpContext")?.GetValue(instance) as HttpContext;
}