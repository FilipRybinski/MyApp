namespace Shared.Core.Options;

public class CorsOptions
{
    public string[] ConnectionUrls { get; set; }
    public string[] AllowedMethods { get; set; }
    public string[] AllowedHeaders { get; set; }
}