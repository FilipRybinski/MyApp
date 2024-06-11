using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Commands.CloseTeam;
using MyApp.Application.Commands.OpenTeam;
using MyApp.Application.Commands.SignUp;
using MyApp.Application.Queries.SignIn;
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
        services.AddScopedValidator<OpenTeam, OpenTeamValidator>();
        services.AddScopedValidator<CloseTeam, CloseTeamValidator>();

        return services;
    }

    private static IServiceCollection AddScopedValidator<TClass, TValidator>(this IServiceCollection services)
        where TClass : class
        where TValidator : class, IValidator<TClass> => services.AddScoped<IValidator<TClass>, TValidator>();
}