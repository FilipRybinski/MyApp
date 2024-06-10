using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Services;
using MyApp.Service.Services;
using QuestPDF.Infrastructure;

namespace MyApp.Service;

public static class Extensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        QuestPDF.Settings.License = LicenseType.Community;
        services.AddScoped<IPdfService, PdfService>();
        return services;
    }
}