using IHttpContextTokenService = Identity.Application.Security.IHttpContextTokenService;

namespace Identity.Application.Handlers.Logout;

internal sealed class LogoutHandler(IHttpContextTokenService httpContextTokenService) : ILogoutHandler
{
    public bool Handle(CancellationToken cancellationToken)
    {
        httpContextTokenService.Remove();
        return true;
    }
}