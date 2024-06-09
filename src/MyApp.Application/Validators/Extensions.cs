using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Commands.SignIn;
using MyApp.Application.Commands.SignUp;
using MyApp.Application.Validators.CommandValidators;

namespace MyApp.Application.Validators;

internal static class Extensions
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();
        services.AddScopedValidator<SignUp, SignUpValidator>();
        services.AddScopedValidator<SignIn, SignInValidator>();
        
        return services;
    }

    private static IServiceCollection AddScopedValidator<TClass,TValidator>(this IServiceCollection services)
        where TClass : class
        where TValidator : class, IValidator<TClass> => services.AddScoped<IValidator<TClass>, TValidator>();
}