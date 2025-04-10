using AutoMapper;
using Identity.Core.DTO;
using Identity.Domain.Identity;

namespace Identity.Application.Mapper.UserIdentityMap;

internal sealed class IdentityProfile : Profile
{
public IdentityProfile()
{
    CreateMap<UserIdentity, IdentityDto>();
}
}