using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Commands;
using MyApp.Application.Handlers;
using MyApp.Application.Mapper;
using MyApp.Application.Queries;
using MyApp.Application.Validators;
using MyApp.Core.DTO;

namespace MyApp.Application;

public static class Extensions
{
    private const string SectionName = "featureFlags";
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<FeatureFlagsDto>(configuration.GetRequiredSection(SectionName));
        
        services.AddCommands();
        services.AddQueries();
        services.AddHandlers();
        services.AddMapper();
        services.AddValidators();
        return services;
    }
    private static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var options = new T();
        var section = configuration.GetSection(sectionName);
        section.Bind(options);
        return options;
    }
}