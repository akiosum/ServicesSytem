using System.Net;
using CrmSystem.Application.Dto.Payments;
using CrmSystem.Application.Requests.Payment;
using FastResults.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrmSystem.Controllers.v1;

[Route("v1/[controller]")]
public class PaymentController : ApiController
{
    public PaymentController(ISender sender) : base(sender)
    {
    }

    [HttpPost]
    public async Task<ActionResult<BaseResponse<PaymentDto>>> CreatePayment(
        [FromBody] CreatePaymentRequest request)
    {
        var result = await Sender.Send(request);
        return Response(result, HttpStatusCode.Created);
    }
}