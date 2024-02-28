using FastResults.Results;
using MediatR;

namespace CrmSystem.Application.Abstraction.Contracts;

public interface IRequestUseCase : IRequest<BaseResult>
{
}

public interface IRequestUseCase<TResponse> : IRequest<BaseResult<TResponse>>
{
}