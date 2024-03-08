namespace CrmSystem.Application.Dto.Payments;

public record PaymentDto(
    long Id,
    string Status,
    string? StatusDetails,
    DateTime? DateExpires,
    string? QrCode,
    string? Url);