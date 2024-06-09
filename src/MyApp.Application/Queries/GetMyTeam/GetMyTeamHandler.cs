using AutoMapper;
using MyApp.Application.Abstractions;
using MyApp.Core.DTO;
using MyApp.Core.Repositories;

namespace MyApp.Application.Queries.GetMyTeam;

public class GetMyTeamHandler : IQueryHandler<GetMyTeam, TeamDto>
{
    private readonly IMapper _mapper;
    private readonly ITeamRepository _teamRepository;
    private readonly IUserRepository _userRepository;

    public GetMyTeamHandler(IUserRepository userRepository, ITeamRepository teamRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _teamRepository = teamRepository;
        _mapper = mapper;
    }

    public async Task<TeamDto> HandleAsync(GetMyTeam query)
    {
        var user = await _userRepository.GetCurrentUser();
        var team = await _teamRepository.GetMyTeam(user.Id);

        return _mapper.Map<TeamDto>(team);
    }
}