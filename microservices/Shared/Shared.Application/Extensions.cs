using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Application;

public static class Extensions
{
    public static IServiceCollection AddScopedValidator<TClass, TValidator>(this IServiceCollection services)
        where TClass : class
        where TValidator : class, IValidator<TClass> => services.AddScoped<IValidator<TClass>, TValidator>();
    
}