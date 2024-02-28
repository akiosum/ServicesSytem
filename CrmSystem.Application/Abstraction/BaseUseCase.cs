using CrmSystem.Application.Abstraction.Contracts;
using FastResults.Results;
using MediatR;

namespace CrmSystem.Application.Abstraction;

public abstract class BaseUseCase<TRequest> : IBaseUseCase<TRequest>
    where TRequest : IRequestUseCase
{
    protected readonly ISender Sender;

    protected BaseUseCase(ISender sender)
    {
        Sender = sender;
    }

    public abstract Task<BaseResult> Handle(TRequest request, CancellationToken cancellationToken);
}

public abstract class BaseUseCase<TRequest, TResponse> : IBaseUseCase<TRequest, TResponse>
    where TRequest : IRequestUseCase<TResponse>
{
    protected readonly ISender Sender;

    protected BaseUseCase(ISender sender)
    {
        Sender = sender;
    }

    public abstract Task<BaseResult<TResponse>> Handle(TRequest request, CancellationToken cancellationToken);
}