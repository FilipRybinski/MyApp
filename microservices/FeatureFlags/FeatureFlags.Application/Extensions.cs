using FeatureFlags.Application.Handlers;
using FeatureFlags.Core.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.CQRS;
using Shared.Mapper;

namespace FeatureFlags.Application;

public static class Extensions
{
    private const string SectionName = "featureFlags";
    public static IServiceCollection AddApplication(this IServiceCollection services,IConfiguration configuration)
    {
        services.Configure<FeatureFlagsDto>(configuration.GetRequiredSection(SectionName));
        services.AddHandlers();
        return services;
    }
}