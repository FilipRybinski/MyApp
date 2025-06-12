using AutoMapper;
using FeeTracker.Core.DTO;
using FeeTracker.Domain.Purpose;

namespace FeeTracker.Application.Mapper.Purpose;

internal sealed class PurposeProfile : Profile
{
    public PurposeProfile()
    {
        CreateMap<FeePurpose, FeePurposeDto>();
    }
}