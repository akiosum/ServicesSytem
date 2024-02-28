using FastResults.Controllers;
using MediatR;

namespace CrmSystem.Controllers;

/// <summary>
/// Class Extension the BaseController
/// </summary>
public abstract class ApiController : BaseController
{
    protected readonly ISender Sender;

    protected ApiController(ISender sender)
    {
        Sender = sender;
    }
}