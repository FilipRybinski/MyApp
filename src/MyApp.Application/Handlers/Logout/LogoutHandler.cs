using MyApp.Application.Security;

namespace MyApp.Application.Handlers.Logout;

public class LogoutHandler : ILogoutHandler
{
    private readonly IHttpContextTokenService _httpContextTokenService;
    
    public LogoutHandler(IHttpContextTokenService httpContextTokenService)
    {
        _httpContextTokenService = httpContextTokenService;
    }

    public bool Handle()
    {
        _httpContextTokenService.Remove();
        return true;
    }
}