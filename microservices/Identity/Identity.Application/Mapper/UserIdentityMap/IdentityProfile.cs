using AutoMapper;
using Identity.Core.DTO;
using Identity.Core.Entities;

namespace Identity.Application.Mapper.UserIdentityMap;

internal sealed class IdentityProfile : Profile
{
public IdentityProfile()
{
    CreateMap<_Identity, IdentityDto>();
}
}