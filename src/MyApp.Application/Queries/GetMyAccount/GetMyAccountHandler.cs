using AutoMapper;
using MyApp.Application.Abstractions;
using MyApp.Application.DTO;
using MyApp.Core.Repositories;

namespace MyApp.Application.Queries.GetMyAccount;

public class GetMyAccountHandler : IQueryHandler<GetMyAccount, UserDto>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetMyAccountHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> HandleAsync(GetMyAccount query)
    {
        var user = await _userRepository.GetCurrentUser();
        if (user is null)
        {
            throw new Exception();
        }

        return _mapper.Map<UserDto>(user);
    }
}