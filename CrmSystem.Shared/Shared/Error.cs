using System.Net;
using CrmSystem.Shared.Enums;
using CrmSystem.Shared.Extensions;

namespace CrmSystem.Shared.Shared;

public class Error
{
    #region Properties

    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.NotFound;

    public TypeError Type { get; private set; } = TypeError.NotFound;

    public string TypeDescription { get; private set; }

    public string Message { get; private set; }

    #endregion Properties

    #region Constructors

    public Error(HttpStatusCode statusCode, TypeError type, string message)
    {
        StatusCode = statusCode;
        Type = type;
        Message = message;
        TypeDescription = Type.GetEnumDescription();
    }

    public Error(HttpStatusCode statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
        TypeDescription = Type.GetEnumDescription();
    }

    public Error(string message)
    {
        Message = message;
        TypeDescription = Type.GetEnumDescription();
    }

    #endregion Constructors

    #region Methods

    public static readonly Error None = new(HttpStatusCode.Continue, TypeError.None, string.Empty);

    #endregion Methods
}