namespace CrmSystem.Domain.Messages;

public static class MessageError
{
    public static string NotFound => "Not Found";
    public static string UnathorizedError => "Access denied. User does not have permission for this action.";
    public static string InternalError => "Internal Error";
}