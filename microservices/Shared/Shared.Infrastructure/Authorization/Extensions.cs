using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Shared.Application;
using Shared.Core.Options;

namespace Shared.Infrastructure.Authorization;

public static class Extensions
{
    private const string AuthSectionName = "auth";
    private const string tokenName = "token";

    public static IServiceCollection ConfigureAuthorization(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AuthorizationOptions>(configuration.GetRequiredSection(AuthSectionName));
        var options = configuration.GetOptions<AuthorizationOptions>(AuthSectionName);

        services
            .AddAuthentication(a =>
            {
                a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddCookie(c => c.Cookie.Name = tokenName)
            .AddJwtBearer(j =>
            {
                j.SaveToken = true;
                j.Audience = options.Audience;
                j.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = options.Issuer,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SigningKey))
                };
                j.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies[tokenName];
                        return Task.CompletedTask;
                    }
                };
            });
        return services;
    }
}