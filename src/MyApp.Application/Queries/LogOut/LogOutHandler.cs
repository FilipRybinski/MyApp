using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Abstractions;
using MyApp.Application.Security;
using MyApp.Core.DTO;

namespace MyApp.Application.Queries.LogOut;

public class LogOutHandler : IEmptyQueryHandler<ActionResultDto>
{
    private readonly IHttpContextTokenStorage _contextTokenStorage;

    public LogOutHandler(IHttpContextTokenStorage contextTokenStorage)
    {
        _contextTokenStorage = contextTokenStorage;
    }
    public async Task<ActionResultDto> HandleAsync()
    {
       return await Task.Run(() => _contextTokenStorage.Remove());
        
    }
}