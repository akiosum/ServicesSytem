using FastResults.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrmSystem.Controllers.v1;

[Route("v1/[controller]")]
public class HomeController : ApiController
{
    public HomeController(ISender sender) : base(sender)
    {
    }

    [HttpGet]
    public async Task<ActionResult<BaseResponse<string>>> Home()
    {
        return Ok();
    }
}