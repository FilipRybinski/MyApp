namespace Identity.Infrastructure.Options;

internal class CookieSettingsOptions
{
    public string Path { get; set; }
    public string Domain { get; set; }
    public int ExpireTime { get; set; }
}