using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using MyApp.Core.DTO;
using MyApp.Core.Repositories;

namespace MyApp.Application.Handlers.GetMyTeam;

public class GetMyTeamHandler : IGetMyTeam
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

    [Authorize]
    public async Task<TeamDto> HandleAsync()
    {
        var user = await _userRepository.GetCurrentUser();
        var team = await _teamRepository.GetMyTeam(user.Id);

        return _mapper.Map<TeamDto>(team);
    }
}