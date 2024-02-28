using CrmSystem.Application.Abstraction;
using CrmSystem.Application.Contracts.Repositories;
using CrmSystem.Application.Entities;
using CrmSystem.Application.Requests;
using FastResults.Results;
using Mapster;
using MediatR;

namespace CrmSystem.Application.UseCases.ProductUseCase;

public class CreateProductUseCase : BaseUseCase<CreateProductRequest, Guid>
{
    #region Properties

    private readonly IProductRepository _productRepository;

    #endregion Properties

    #region Constructors

    public CreateProductUseCase(ISender sender, IProductRepository productRepository) : base(sender)
    {
        _productRepository = productRepository;
    }

    #endregion Constructors

    public override async Task<BaseResult<Guid>> Handle(CreateProductRequest request,
        CancellationToken cancellationToken)
    {
        Product product = request.Adapt<Product>();
        Product productCreated = await _productRepository.Add(product, cancellationToken);

        return productCreated.Id;
    }
}