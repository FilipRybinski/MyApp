using MyApp.Application.Abstractions;
using MyApp.Application.DTO;
using MyApp.Core.Repositories;

namespace MyApp.Application.Queries.Handlers;

public class GetUsersHandler : IQueryHandler<GetUsers,IEnumerable<UserDto>>
{
    private readonly IUserRepository _userRepository;
    
    public GetUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public Task<IEnumerable<UserDto>> HandleAsync(GetUsers query)
    {
        throw new NotImplementedException();
    }
}