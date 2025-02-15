using Identity.Infrastructure.Authorization;
using Identity.Infrastructure.DAL;
using Identity.Infrastructure.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure;

namespace Identity.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPostgres(configuration);
        services.AddSecurity();
        services.AddAuth(configuration);
        services.AddHttpContextAccessor();
        services.AddSharedInfrastructure(configuration);
        
        return services;
    }
    
}