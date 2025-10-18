using MediatR;
using Shared.Core.Objects;

namespace Shared.Application.Abstractions.CQRS;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
