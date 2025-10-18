using Microsoft.Extensions.DependencyInjection;
using QueueMailer.Application.Repositories;
using QueueMailer.Infrastructure.Template.Reader;

namespace QueueMailer.Infrastructure.Template;

public static class Extensions
{
    public static IServiceCollection AddTemplateUtils(this IServiceCollection services)
    {
        services.AddScoped<IEmailTemplateReader, EmailTemplateReader>();
        
        return services;
    }
}