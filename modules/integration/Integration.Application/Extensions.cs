using Integration.Application.Commands;
using Integration.Application.Handlers;
using Integration.Application.Mapper;
using Integration.Application.Queries;
using Integration.Application.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Integration.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddCommands();
        services.AddQueries();
        services.AddHandlers();
        services.AddMapper();
        services.AddValidators();
        return services;
    }
}