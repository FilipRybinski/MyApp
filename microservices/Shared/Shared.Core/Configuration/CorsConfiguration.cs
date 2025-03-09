namespace Shared.Core.Configuration;

public sealed class CorsConfiguration
{
    public string[] ConnectionUrls { get; set; }
    public string[] AllowedMethods { get; set; }
    public string[] AllowedHeaders { get; set; }
}