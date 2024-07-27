using Microsoft.Extensions.Options;
using MyApp.Core.Dictionary;
using MyApp.Core.DTO;
using MyApp.Core.Repositories;

namespace MyApp.Application.Handlers.GetFeatureFlags;

public class GetFeatureFlagsHandler : IGetFeatureFlagsHandler
{
    private readonly IUserRepository _userRepository;
    private readonly FeatureFlagsDto FeatureFlags;

    public GetFeatureFlagsHandler(IUserRepository userRepository,IOptions<FeatureFlagsDto> featureFlags)
    {
        _userRepository = userRepository;
        FeatureFlags = featureFlags.Value;
    }

    public async Task<FeatureFlagsDto> HandleAsync()
    {
        var user = await _userRepository.GetUser();
        if (user is null)
        {
            throw new Exception();
        }
        
        return FeatureFlags;
    }
}