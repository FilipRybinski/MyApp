using AutoMapper;
using MyApp.Core.DTO;
using MyApp.Core.Repositories;

namespace MyApp.Application.Handlers.GetMyAccount;

public class GetMyAccountHandler : IGetMyAccountHandler
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetMyAccountHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> HandleAsync()
    {
        var user = await _userRepository.GetCurrentUser();
        if (user is null)
        {
            throw new Exception();
        }

        return _mapper.Map<UserDto>(user);
    }
}