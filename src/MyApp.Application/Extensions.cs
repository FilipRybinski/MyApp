using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Commands;
using MyApp.Application.Handlers;
using MyApp.Application.Mapper;
using MyApp.Application.Queries;
using MyApp.Application.Validators;

namespace MyApp.Application;

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