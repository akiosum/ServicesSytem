using CrmSystem.Application.Requests;
using FluentValidation;

namespace CrmSystem.Application.Validators.Product;

public class CreateProductValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(3)
            .WithMessage("Nome precisa ser maior que 3");
    }
}