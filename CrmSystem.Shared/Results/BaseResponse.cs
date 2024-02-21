using CrmSystem.Shared.Shared;

namespace CrmSystem.Shared.Results;

public class BaseResponse<TResponse>
{
    #region Properties

    public TResponse? Data { get; private set; }

    public Error Error { get; private set; }

    #endregion Properties

    #region Constructors

    public BaseResponse(TResponse? data)
    {
        Data = data;
        Error = Error.None;
    }

    public BaseResponse(Error error)
    {
        Data = default;
        Error = error;
    }

    #endregion Constructors
}