using FeeTracker.Core.DTO;
using Shared.Application.Abstractions.CQRS;

namespace FeeTracker.Application.Queries.Purpose.Get;

public record GetFeePurpose() : IQuery<List<FeePurposeDto>>;