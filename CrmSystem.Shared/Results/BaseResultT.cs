using CrmSystem.Shared.Shared;

namespace CrmSystem.Shared.Results;

public class BaseResult<TValue> : BaseResult
{
    #region Properties

    public TValue Value { get; }

    #endregion Properties

    #region Constructors

    protected internal BaseResult(TValue? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        Value = value!;
    }

    #endregion Constructors

    public static implicit operator BaseResult<TValue>(TValue? value) => Create(value);
}