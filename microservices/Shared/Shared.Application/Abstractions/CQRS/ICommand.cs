using MediatR;
using Shared.Core.Objects;

namespace Shared.Application.Abstractions.CQRS;

public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

public interface IBaseCommand;
