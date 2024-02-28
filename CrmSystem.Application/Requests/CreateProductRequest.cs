using CrmSystem.Application.Abstraction.Contracts;

namespace CrmSystem.Application.Requests;

public record CreateProductRequest(
    string Name,
    decimal Price,
    decimal Cost) : IRequestUseCase<Guid>;