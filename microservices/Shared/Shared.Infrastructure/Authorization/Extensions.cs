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
    private const string OutsideAuthSectionName = "auth";
    private const string InternalAuthSectionName = "internal-auth";
    private const string tokenName = "token";

    public static IServiceCollection ConfigureAuthorization(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<OutsideAuthorizationOptions>(configuration.GetRequiredSection(OutsideAuthSectionName));
        services.Configure<InternalAuthorizationOptions>(configuration.GetRequiredSection(InternalAuthSectionName));
        var outsideAuth = configuration.GetOptions<OutsideAuthorizationOptions>(OutsideAuthSectionName);
        var internalAuth = configuration.GetOptions<InternalAuthorizationOptions>(InternalAuthSectionName);

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
                j.Audience = outsideAuth.Audience;
                j.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = outsideAuth.Issuer,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(outsideAuth.SigningKey))
                };
                j.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies[tokenName];
                        return Task.CompletedTask;
                    }
                };
            })
            .AddJwtBearer(j =>
            {
                j.SaveToken = true;
                j.Audience = internalAuth.Audience;
                j.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = internalAuth.Issuer,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(internalAuth.SigningKey))
                };
            });
        return services;
    }
}