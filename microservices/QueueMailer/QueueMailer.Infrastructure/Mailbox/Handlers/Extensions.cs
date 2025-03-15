using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using QueueMailer.Core.Abstractions;

namespace QueueMailer.Infrastructure.Mailbox.Handlers;

public static class Extensions
{
    public static IServiceCollection AddMailboxHandler(this IServiceCollection services)
    {
        services.Scan(s => s.FromAssemblies(Assembly.GetExecutingAssembly())
            .AddClasses(c => c.AssignableTo(typeof(IMailboxHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}