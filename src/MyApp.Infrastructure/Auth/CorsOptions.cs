namespace MyApp.Infrastructure.Auth;

public class CorsOptions
{
    public string ConnectionUrl { get; set; }
    public string[] AllowedMethods { get; set; }
    public string[] AllowedHeaders { get; set; }
}