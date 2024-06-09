using AutoMapper;
using MyApp.Application.DTO;
using MyApp.Core.Entities;

namespace MyApp.Application.Mapper.UserMap;

internal class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
    }
}