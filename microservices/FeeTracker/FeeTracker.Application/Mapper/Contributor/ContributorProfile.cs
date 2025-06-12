using AutoMapper;
using FeeTracker.Core.DTO;
using FeeTracker.Domain.Contributor;
using FeeTracker.Domain.PurposeOwner;
using Shared.Core.DTO;

namespace FeeTracker.Application.Mapper.Contributor;

internal sealed class ContributorProfile : Profile
{
    public ContributorProfile()
    {
        CreateMap<FeeContributor, FeeContributorDto>();
        CreateMap<FeeContributor, IdentityDto>();
    }
}