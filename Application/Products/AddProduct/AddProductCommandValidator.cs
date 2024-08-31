using FluentValidation;

namespace Application.Products.AddProduct;

public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
{
    public AddProductCommandValidator()
    {
        RuleFor(p => p.Price).GreaterThan(0);

        RuleFor(p => (int)p.Quantity).GreaterThanOrEqualTo(0);
    }
}