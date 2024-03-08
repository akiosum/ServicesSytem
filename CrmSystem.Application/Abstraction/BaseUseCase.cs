using CrmSystem.Application.Abstraction.Contracts;
using FastResults.Results;
using MediatR;

namespace CrmSystem.Application.Abstraction;

public abstract class BaseUseCase<TRequest> : IBaseUseCase<TRequest>
    where TRequest : IRequestUseCase
{
    #region Properties

    protected readonly ISender Sender;

    #endregion Properties

    #region Constructors

    protected BaseUseCase(ISender sender)
    {
        Sender = sender;
    }

    #endregion Constructors

    public abstract Task<BaseResult> Handle(TRequest request, CancellationToken cancellationToken);
}

public abstract class BaseUseCase<TRequest, TResponse> : IBaseUseCase<TRequest, TResponse>
    where TRequest : IRequestUseCase<TResponse>
{
    #region Properties

    protected readonly ISender Sender;

    #endregion Properties

    #region Constructors

    protected BaseUseCase(ISender sender)
    {
        Sender = sender;
    }

    #endregion Constructors

    public abstract Task<BaseResult<TResponse>> Handle(TRequest request, CancellationToken cancellationToken);
}