using AutoMapper;
using Identity.Core.DTO;
using Identity.Domain.Identity;
using Shared.Core.DTO;

namespace Identity.Application.Mapper.UserIdentityMap;

internal sealed class IdentityProfile : Profile
{
    public IdentityProfile()
    {
        CreateMap<UserIdentity, IdentityDto>();
    }
}