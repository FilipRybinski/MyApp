namespace MyApp.Core.DTO;

public class CookieSettingsDto
{
    public string Path { get; set; }
    public string Domain { get; set; }
    public int ExpireTime { get; set; }
}