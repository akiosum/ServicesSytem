using CrmSystem.Shared.Shared;

namespace CrmSystem.Shared.Results;

public class BaseResult
{
    #region Properties

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    #endregion Properties

    #region Constructors

    protected BaseResult(bool isSuccess, Error error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    #endregion Constructors

    #region Methods

    #region Success

    public static BaseResult Sucess() => new(true, Error.None);
    public static BaseResult<TValue> Sucess<TValue>(TValue value) => new(value, true, Error.None);

    #endregion Success

    #region Failure

    public static BaseResult Failure(string message) => new(false, new(message));
    public static BaseResult Failure(Error error) => new(false, error);
    public static BaseResult<TValue> Failure<TValue>(string message) => new(default, false, new(message));
    public static BaseResult<TValue> Failure<TValue>(Error error) => new(default, false, error);

    #endregion Failure

    protected static BaseResult<TValue> Create<TValue>(TValue? value) =>
        value is not null ? Sucess(value) : Failure<TValue>(Error.None);

    #endregion Methods
}