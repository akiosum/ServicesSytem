namespace CrmSystem.Application.Dto.Products;

public record ProductDto(
    Guid Id, 
    string Name, 
    decimal Price, 
    decimal Cost);