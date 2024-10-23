using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MyApp.Application.Security;
using MyApp.Core.DTO;
using MyApp.Infrastructure.DAL;

namespace MyApp.Infrastructure.Auth;

internal static class Extensions
{
    private const string AuthSectionName = "auth";
    private const string CookieSettingsSectionName = "cookieSettings";
    private const string tokenName = "token";

    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AuthOptions>(configuration.GetRequiredSection(AuthSectionName));
        services.Configure<CookieSettingsDto>(configuration.GetRequiredSection(CookieSettingsSectionName));
        var options = configuration.GetOptions<AuthOptions>(AuthSectionName);

        services
            .AddSingleton<IAuthenticator, Authenticator>()
            .AddSingleton<Application.Security.IHttpContextTokenService, HttpContextTokenService>()
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