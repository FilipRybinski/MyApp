using MyApp.Application.Abstractions;
using MyApp.Application.DTO;
using MyApp.Core.Repositories;

namespace MyApp.Application.Queries.Handlers;

public sealed class GetUserHandler : IQueryHandler<GetUser,UserDto>
{
    private readonly IUserRepository _userRepository;
    
    public GetUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public Task<UserDto> HandleAsync(GetUser query)
    {
        throw new NotImplementedException();
    }
}