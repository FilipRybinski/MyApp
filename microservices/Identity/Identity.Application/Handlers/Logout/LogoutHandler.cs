using IHttpContextTokenService = Identity.Application.Security.IHttpContextTokenService;

namespace Identity.Application.Handlers.Logout;

public class LogoutHandler(IHttpContextTokenService httpContextTokenService) : ILogoutHandler
{
    public bool Handle()
    {
        httpContextTokenService.Remove();
        return true;
    }
}