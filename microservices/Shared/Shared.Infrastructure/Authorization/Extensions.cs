using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Shared.Core.Configuration;
using Shared.Core.Objects;
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
                    },
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.ContentType = "application/json";
                        var response =
                            JsonSerializer.Serialize(
                                Result.Failure(Error.Unauthorized("Unauthorized: Token is missing or invalid")));
                        return context.Response.WriteAsync(response);

                    },
                    OnForbidden = context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        context.Response.ContentType = "application/json";
                        var response =
                            JsonSerializer.Serialize(
                                Result.Failure(Error.Unauthorized("Forbidden: Token is missing or invalid")));
                        return context.Response.WriteAsync(response);
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