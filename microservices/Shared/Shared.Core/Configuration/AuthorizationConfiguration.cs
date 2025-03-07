namespace Shared.Core.Configuration;

public class AuthorizationConfiguration
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SigningKey { get; set; }
    public TimeSpan? Expiry { get; set; }
}

public sealed class ExternalAuthorizationConfiguration : AuthorizationConfiguration { }

public sealed class InternalAuthorizationConfiguration : AuthorizationConfiguration { }
