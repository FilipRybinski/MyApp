namespace Shared.Core.Options;

public class AuthorizationOptions
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SigningKey { get; set; }
    public TimeSpan? Expiry { get; set; }
}

public class OutsideAuthorizationOptions : AuthorizationOptions { }

public class InternalAuthorizationOptions : AuthorizationOptions { }
