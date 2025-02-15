using FluentValidation.AspNetCore;
using Identity.Application.Queries.SignIn;
using Identity.Application.Queries.SignUp;
using Microsoft.Extensions.DependencyInjection;
using Shared;


namespace Identity.Application.Validators;

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
}