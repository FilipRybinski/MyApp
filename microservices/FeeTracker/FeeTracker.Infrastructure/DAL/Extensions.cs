using FeeTracker.Core.Repositories;
using FeeTracker.Infrastructure.DAL.Context;
using FeeTracker.Infrastructure.DAL.Initializer;
using FeeTracker.Infrastructure.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.DAL;

namespace FeeTracker.Infrastructure.DAL;

internal static class Extensions
{
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterPostgres<FeeTrackerDbContext>(configuration);
        services.AddHostedService<DatabaseInitializer>();
        services.AddScoped<IFeeContributorRepository, PostgresFeeContributorRepository>();
        services.AddScoped<IFeePurposeOwnerRepository, PostgresFeePurposeOwnerRepository>();
        services.AddScoped<IFeeParticipantRepository, PostgresFeeParticipantRepository>();
        services.AddScoped<IFeePurposeRepository, PostgresFeePurposeRepository>();
        return services;
    }
}