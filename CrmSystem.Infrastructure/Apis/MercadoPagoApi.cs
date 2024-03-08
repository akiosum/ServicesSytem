using CrmSystem.Application.Contracts.Infrastructure;
using CrmSystem.Application.Dto.Payments;
using CrmSystem.Infrastructure.Abstractions;
using FastResults.Results;
using MercadoPago.Client;
using MercadoPago.Client.Common;
using MercadoPago.Client.Payment;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;
using RestSharp;

namespace CrmSystem.Infrastructure.Apis;

public class MercadoPagoApi : BaseInfrastructure, IMercadoPagoApi
{
    #region Properties

    private readonly RestClient _restClient;
    private readonly string _token = "TEST-874639157958008-030515-fb7365e647c74e8181f47ab06c7fca71-227964485";

    #endregion Properties

    #region Constructors

    public MercadoPagoApi()
    {
        RestClientOptions options = new RestClientOptions("https://api.mercadopago.com/");

        _restClient = new RestClient();
    }

    #endregion Constructors

    public async Task<BaseResult<PaymentDto>> CreatePix(CreatePaymentDto request, CancellationToken cancellationToken)
    {
        MercadoPagoConfig.AccessToken = _token;
        var requestOptions = new RequestOptions();
        requestOptions.CustomHeaders.Add("x-idempotency-key", $"{request.Key}");

        PaymentCreateRequest paymentCreate = new PaymentCreateRequest
        {
            TransactionAmount = request.Amount,
            Description = "Teste",
            PaymentMethodId = request.PaymentMethod,
            DateOfExpiration = DateTime.Now.AddMinutes(5),
            Payer = new PaymentPayerRequest
            {
                Email = request.PersonVa?.Email,
                FirstName = request.PersonVa?.FirstName,
                LastName = request.PersonVa?.LastName,
                Identification = new IdentificationRequest
                {
                    Type = request.PersonVa?.Identification.Type,
                    Number = request.PersonVa?.Identification.Document
                },
            },
        };

        PaymentClient client = new PaymentClient();
        Payment payment = await client.CreateAsync(paymentCreate, requestOptions, cancellationToken);

        return new PaymentDto(
            payment.Id ?? 0,
            payment.Status,
            payment.StatusDetail,
            payment.DateOfExpiration ?? DateTime.Now,
            payment.PointOfInteraction.TransactionData.QrCodeBase64,
            payment.PointOfInteraction.TransactionData.TicketUrl);
    }

    public async Task<BaseResult> GetOperationById(long id)
    {
        throw new NotImplementedException();
    }
}