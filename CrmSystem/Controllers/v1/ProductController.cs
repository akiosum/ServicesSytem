using System.Net;
using CrmSystem.Application.Requests;
using FastResults.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrmSystem.Controllers.v1;

[Route("v1/[controller]")]
public class ProductController : ApiController
{
    #region Constructors

    public ProductController(ISender sender) : base(sender)
    {
    }

    #endregion Constructors

    [HttpPost]
    public async Task<ActionResult<BaseResponse<string>>> CreateProduct([FromBody] CreateProductRequest request)
    {
        var result = await Sender.Send(request);
        return Response(result, HttpStatusCode.Created);
    }
}