using AutoMapper;
using MyApp.Core.DTO;
using MyApp.Core.Entities;
using MyApp.Core.Repositories;

namespace MyApp.Application.Handlers.IsAuthorized;

public class AuthorizedHandler : IAuthorizedHandler
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public AuthorizedHandler(IUserRepository userRepository,IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<UserDto?> HandleAsync()
    {
        return _mapper.Map<UserDto>(await _userRepository.GetSessionUserAsync());
    }
}