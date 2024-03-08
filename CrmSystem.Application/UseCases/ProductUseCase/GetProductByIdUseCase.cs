using CrmSystem.Application.Abstraction;
using CrmSystem.Application.Contracts.Repositories;
using CrmSystem.Application.Dto.Products;
using CrmSystem.Application.Entities;
using CrmSystem.Application.Requests;
using CrmSystem.Shared.Messages;
using FastResults.Results;
using Mapster;
using MediatR;

namespace CrmSystem.Application.UseCases.ProductUseCase;

public class GetProductByIdUseCase : BaseUseCase<GetProductById, ProductDto>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdUseCase(ISender sender, IProductRepository productRepository) : base(sender)
    {
        _productRepository = productRepository;
    }

    public override async Task<BaseResult<ProductDto>> Handle(GetProductById request,
        CancellationToken cancellationToken)
    {
        Product? product = await _productRepository.GetById(request.Id);
        if (product is null)
        {
            return BaseResult.Failure<ProductDto>(MessageError.NotFound);
        }

        return product.Adapt<ProductDto>();
    }
}