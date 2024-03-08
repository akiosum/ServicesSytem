using System.ComponentModel;

namespace CrmSystem.Shared.Enums;

public enum TypePayment
{
    [Description("Dinheiro")]
    Dinheiro = 1,
    
    [Description("Pix")]
    Pix = 2
}