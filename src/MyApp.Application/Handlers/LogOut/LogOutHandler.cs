using MyApp.Application.Security;

namespace MyApp.Application.Queries.LogOut;

public class LogOutHandler : ILogOut
{
    private readonly IHttpContextTokenStorage _contextTokenStorage;
    private ILogOut _logOutImplementation;

    public LogOutHandler(IHttpContextTokenStorage contextTokenStorage)
    {
        _contextTokenStorage = contextTokenStorage;
    }

    public async Task HandleAsync()
    {
        await Task.Run(() => _contextTokenStorage.Remove());
    }
}