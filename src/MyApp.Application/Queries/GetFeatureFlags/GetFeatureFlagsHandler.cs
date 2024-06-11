using MyApp.Application.Abstractions;
using MyApp.Core.Dictionary;
using MyApp.Core.DTO;
using MyApp.Core.Repositories;

namespace MyApp.Application.Queries.GetFeatureFlags;

public class GetFeatureFlagsHandler : IEmptyQueryHandler<FeatureFlagsDto>
{
    private readonly IUserRepository _userRepository;

    public GetFeatureFlagsHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<FeatureFlagsDto> HandleAsync()
    {
        var user = await _userRepository.GetCurrentUser();
        var featureFlags = user.Role.Name switch
        {
            UserRoleDictionary.Moderator => new FeatureFlagsDto(false, true, false),
            UserRoleDictionary.Administrator => new FeatureFlagsDto(false, true, false),
            _ => new FeatureFlagsDto(false, true, false),
        };

        return featureFlags;
    }
}