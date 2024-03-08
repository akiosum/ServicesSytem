using CrmSystem.Application.Dto.Person;
using CrmSystem.Shared.Enums;

namespace CrmSystem.Application.Dto.Payments;

public class CreatePaymentDto
{
    #region Properties

    public decimal Amount { get; set; } = decimal.Zero;
    public PersonPaymentDto PersonVa { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string Key { get; set; } = GenerateKey;

    #endregion Properties

    #region Methods

    private static string GenerateKey => Guid.NewGuid().ToString();

    public void ReturnPaymentMethod(TypePayment typePayment)
    {
        PaymentMethod = typePayment switch
        {
            TypePayment.Pix => "pix",
            _ => "dinheiro"
        };
    }

    #endregion Methods
}