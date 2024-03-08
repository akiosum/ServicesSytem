using FastResults.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrmSystem.Controllers.v1;

[Route("v1/[controller]")]
public class HomeController : ApiController
{
    #region Constructors

    public HomeController(ISender sender) : base(sender)
    {
    }

    #endregion Constructors

    [HttpGet]
    public ActionResult<BaseResponse<string>> Home()
    {
        return Response(BaseResult.Sucess(), "Api Open");
    }
}