using CrmSystem.Application.Abstraction.Contracts;
using CrmSystem.Application.Dto.Payments;
using CrmSystem.Application.Dto.Person;
using CrmSystem.Shared.Enums;

namespace CrmSystem.Application.Requests.Payment;

public class CreatePaymentRequest : IRequestUseCase<PaymentDto>
{
    public decimal Amount { get; private set; }
    public TypePayment Type { get; private set; }
    public PersonPaymentDto Person { get; private set; }

    public CreatePaymentRequest(
        decimal amount,
        TypePayment type,
        PersonPaymentDto person)
    {
        Amount = amount;
        Type = type;
        Person = person;
    }
}