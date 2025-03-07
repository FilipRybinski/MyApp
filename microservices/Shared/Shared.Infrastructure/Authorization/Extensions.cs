using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Shared.Core.Configuration;
using Shared.Core.Policies;

namespace Shared.Infrastructure.Authorization;

internal static class Extensions
{

    public static IServiceCollection ConfigureAuthorization(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ExternalAuthorizationConfiguration>(configuration.GetRequiredSection(nameof(ExternalAuthorizationConfiguration)));
        services.Configure<InternalAuthorizationConfiguration>(configuration.GetRequiredSection(nameof(InternalAuthorizationConfiguration)));
        var externalAuth = configuration.GetOptions<ExternalAuthorizationConfiguration>(nameof(ExternalAuthorizationConfiguration));
        var internalAuth = configuration.GetOptions<InternalAuthorizationConfiguration>(nameof(InternalAuthorizationConfiguration));

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddCookie(c => c.Cookie.Name = "token")
            .AddJwtBearer(AuthPolicies.External,j =>
            {
                j.SaveToken = true;
                j.Audience = externalAuth.Audience;
                j.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = externalAuth.Issuer,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(externalAuth.SigningKey))
                };
                j.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["token"];
                        return Task.CompletedTask;
                    }
                };
            })
            .AddJwtBearer(AuthPolicies.Internal,j =>
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
        
        services.AddAuthorization(options =>
        {
            var defaultPolicy =
                new AuthorizationPolicyBuilder(AuthPolicies.External, AuthPolicies.Internal)
                    .RequireAuthenticatedUser()
                    .Build();
            options.DefaultPolicy = defaultPolicy;
            
            options.AddPolicy(AuthPolicies.External, policy => policy.AddAuthenticationSchemes(AuthPolicies.External).RequireAuthenticatedUser());
            options.AddPolicy(AuthPolicies.Internal, policy => policy.AddAuthenticationSchemes(AuthPolicies.Internal).RequireAuthenticatedUser());
        });
        
        return services;
    }
}