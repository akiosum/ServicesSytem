using System.Net;
using FastResults.Enums;
using FastResults.Errors;
using FastResults.Results;
using FluentValidation;
using MediatR;

namespace CrmSystem.Application.Behaviors;

public class ValidationPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : BaseResult
{
    #region Properties

    private readonly IEnumerable<IValidator<TRequest>> _fluentValidators;

    #endregion Properties

    #region Constructors

    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> fluentValidators)
    {
        _fluentValidators = fluentValidators;
    }

    #endregion Constructors

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        List<Error> errors = _fluentValidators
            .Select(validator => validator.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(error => error is not null)
            .Select(error => new Error(
                HttpStatusCode.NotFound,
                error.ErrorMessage,
                TypeError.Validation))
            .Distinct()
            .ToList();

        if (errors.Any())
        {
            CreatedErrors(errors);
        }

        return await next();
    }

    private void CreatedErrors(List<Error> errors)
    {
        List<string> messages = errors
            .Select(error => error.Message)
            .ToList();
        string message = string.Join(",", messages);

        throw new ValidationException(message);
    }
}