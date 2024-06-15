using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Handlers.GetAvailableMembers;
using MyApp.Application.Handlers.GetFeatureFlags;
using MyApp.Application.Handlers.GetMyAccount;
using MyApp.Application.Handlers.GetMyTeam;
using MyApp.Application.Handlers.GetMyTeamMembers;

namespace MyApp.Application.Handlers;

public static class Extensions
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddScopedHandler<IGetAvailableMembersHandler, GetAvailableMembersHandler>();
        services.AddScopedHandler<IGetFeatureFlagsHandler, GetFeatureFlagsHandler>();
        services.AddScopedHandler<IGetMyAccountHandler, GetMyAccountHandler>();
        services.AddScopedHandler<IGetMyTeam, GetMyTeamHandler>();
        services.AddScopedHandler<IGetMyTeamMembersHandler, GetMyTeamMembersHandler>();
        return services;
    }

    private static IServiceCollection AddScopedHandler<TInterface, TClass>(this IServiceCollection services)
        where TClass : class, TInterface where TInterface : class => services.AddScoped<TInterface, TClass>();
}