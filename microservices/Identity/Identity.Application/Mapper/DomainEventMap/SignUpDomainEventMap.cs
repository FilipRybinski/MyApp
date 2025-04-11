using AutoMapper;
using Identity.Domain.Identity;
using Shared.Application.Commands.SendConfirmationEmail;

namespace Identity.Application.Mapper.DomainEventMap;

public class SignUpDomainEventMap : Profile
{
    public SignUpDomainEventMap()
    {
        CreateMap<UserIdentitySignUpDomainEvent, ConfirmationEmail>();
    }
}