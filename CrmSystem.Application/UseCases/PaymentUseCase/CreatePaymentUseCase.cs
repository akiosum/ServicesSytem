using CrmSystem.Application.Abstraction;
using CrmSystem.Application.Contracts.Infrastructure;
using CrmSystem.Application.Dto.Payments;
using CrmSystem.Application.Requests.Payment;
using CrmSystem.Shared.Enums;
using FastResults.Results;
using Mapster;
using MediatR;

namespace CrmSystem.Application.UseCases.PaymentUseCase;

public class CreatePaymentUseCase : BaseUseCase<CreatePaymentRequest, PaymentDto>
{
    #region Properties

    private readonly IMercadoPagoApi _mercadoPagoApi;

    #endregion Properties

    #region Constructors

    public CreatePaymentUseCase(
        ISender sender,
        IMercadoPagoApi mercadoPagoApi) : base(sender)
    {
        _mercadoPagoApi = mercadoPagoApi;
    }

    #endregion Constructors

    public override async Task<BaseResult<PaymentDto>> Handle(
        CreatePaymentRequest request,
        CancellationToken cancellationToken)
    {
        CreatePaymentDto paymentDto = request.Adapt<CreatePaymentDto>();
        paymentDto.PersonVa = request.Person;
        paymentDto.ReturnPaymentMethod(request.Type);

        var result = await CreatePayment(paymentDto, request, cancellationToken);

        return result;
    }

    private async Task<BaseResult<PaymentDto>> CreatePayment(
        CreatePaymentDto paymentDto,
        CreatePaymentRequest request,
        CancellationToken cancellationToken)
    {
        switch (request.Type)
        {
            case TypePayment.Pix:
                return await PaymentPix(paymentDto, cancellationToken);
            case TypePayment.Dinheiro:
                return BaseResult.Sucess(new PaymentDto(0, "", string.Empty, DateTime.Now, string.Empty, string.Empty));
            default:
                return BaseResult.Failure<PaymentDto>("Not Implementation");
        }
    }

    private Task<BaseResult<PaymentDto>> PaymentPix(
        CreatePaymentDto paymentDto,
        CancellationToken cancellationToken)
    {
        return _mercadoPagoApi.CreatePix(paymentDto, cancellationToken);
    }
}