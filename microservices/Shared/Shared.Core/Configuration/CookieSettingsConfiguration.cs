namespace Shared.Core.Configuration;

public sealed class CookieSettingsConfiguration
{
    public string Path { get; set; }
    public string Domain { get; set; }
    public int ExpireTime { get; set; }
}