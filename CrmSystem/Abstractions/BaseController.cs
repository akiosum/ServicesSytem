using System.Net;
using CrmSystem.Shared.Results;
using CrmSystem.Shared.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CrmSystem.Abstractions;

[ApiController]
public abstract class BaseController : ControllerBase
{
    protected new ActionResult Response(
        BaseResult result,
        HttpStatusCode httpStatus = HttpStatusCode.OK,
        HttpStatusCode httpStatusError = HttpStatusCode.NotFound,
        string message = "")
    {
        if (result.IsFailure)
        {
            result.Error.StatusCode = httpStatusError;
            return StatusCode((int)httpStatusError, new BaseResponse<Error>(result.Error));
        }

        return StatusCode((int)httpStatus, new BaseResponse<string>(message));
    }

    protected new ActionResult Response<TResponse>(
        BaseResult<TResponse> result,
        HttpStatusCode httpStatus = HttpStatusCode.OK,
        HttpStatusCode httpStatusError = HttpStatusCode.NotFound)
    {
        if (result.IsFailure)
        {
            result.Error.StatusCode = httpStatusError;
            return StatusCode((int)httpStatusError, new BaseResponse<Error>(result.Error));
        }

        return StatusCode((int)httpStatus, new BaseResponse<TResponse>(result.Value));
    }
}