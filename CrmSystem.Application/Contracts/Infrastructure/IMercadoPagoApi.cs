using CrmSystem.Application.Dto.Payments;
using FastResults.Results;

namespace CrmSystem.Application.Contracts.Infrastructure;

public interface IMercadoPagoApi
{
    Task<BaseResult<PaymentDto>> CreatePix(CreatePaymentDto request, CancellationToken cancellationToken);
    Task<BaseResult> GetOperationById(long id);
}