using System.Security.Cryptography;
using TokenRegistry.Core.Providers;

namespace TokenRegistry.Infrastructure.Providers.Token;

internal sealed class TokenProvider : ITokenProvider
{
    public string Handle()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
        }
        return Convert.ToBase64String(randomNumber);
    }
}