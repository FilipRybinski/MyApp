using AutoMapper;
using MyApp.Application.Abstractions;
using MyApp.Core.DTO;
using MyApp.Core.Repositories;

namespace MyApp.Application.Queries.GetUserByIdentifier;

public class GetUserByIdentifierHandler : IQueryHandler<GetUserByIdentifier, UserDto>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetUserByIdentifierHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> HandleAsync(GetUserByIdentifier query)
    {
        var user = await _userRepository.GetUserWithIdentifier(query.Id);
        return _mapper.Map<UserDto>(user);
    }
}