using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Integration.Application.Validators;

internal static class Extension
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();
        
        return services;
    }

    private static IServiceCollection AddScopedValidator<TClass, TValidator>(this IServiceCollection services)
        where TClass : class
        where TValidator : class, IValidator<TClass> => services.AddScoped<IValidator<TClass>, TValidator>();
}