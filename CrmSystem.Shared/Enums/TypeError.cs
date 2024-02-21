using System.ComponentModel;

namespace CrmSystem.Shared.Enums;

public enum TypeError
{
    [Description("None")]
    None = 0,
    
    [Description("Internal Error")]
    InternalError = 1,
    
    [Description("Not Found")]
    NotFound = 2,
    
    [Description("Unauthorized")]
    Unauthorized = 2,
    
    [Description("Validation")]
    Validation = 4
}