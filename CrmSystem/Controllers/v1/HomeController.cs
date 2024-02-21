using CrmSystem.Abstractions;
using CrmSystem.Shared.Results;
using Microsoft.AspNetCore.Mvc;

namespace CrmSystem.Controllers.v1;

[Route("v1/[controller]")]
public class HomeController : BaseController
{
    [HttpGet]
    public ActionResult<BaseResponse<string>> Home()
    {
        return Response(BaseResult.Sucess(), message: "Api online");
    }
}