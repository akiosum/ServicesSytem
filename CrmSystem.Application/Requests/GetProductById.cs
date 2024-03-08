using CrmSystem.Application.Abstraction.Contracts;
using CrmSystem.Application.Dto.Products;
using MediatR;

namespace CrmSystem.Application.Requests;

public record GetProductById(Guid Id) : IRequestUseCase<ProductDto>;