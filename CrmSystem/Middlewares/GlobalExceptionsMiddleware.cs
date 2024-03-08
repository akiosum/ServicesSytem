using System.Net;
using CrmSystem.Shared.Messages;
using FastResults.Enums;
using FastResults.Errors;
using FastResults.Results;

namespace CrmSystem.Middlewares;

public class GlobalExceptionsMiddleware : IMiddleware
{
    #region Properties

    private readonly ILogger<GlobalExceptionsMiddleware> _logger;

    #endregion Properties

    #region Constructors

    public GlobalExceptionsMiddleware(ILogger<GlobalExceptionsMiddleware> logger)
    {
        _logger = logger;
    }

    #endregion Constructors

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            _logger.LogInformation($"Route - {context.Request.Path}");
            await next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"Error - {exception.Message}");
            var response = context.Response;
            response.ContentType = "application/json";

            switch (exception)
            {
                case UnauthorizedAccessException:
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    await response.WriteAsJsonAsync(
                        new Error(HttpStatusCode.Unauthorized, MessageError.UnathorizedError, TypeError.Unauthorized));
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    await response.WriteAsJsonAsync(new BaseResponse<string>(
                        new Error(HttpStatusCode.InternalServerError, "Internal Error", TypeError.InternalError)));
                    break;
                
            }
        }
    }
}