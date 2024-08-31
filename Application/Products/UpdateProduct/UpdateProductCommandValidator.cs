using FluentValidation;

namespace Application.Products.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(p => p.Price).GreaterThan(0);

        RuleFor(p => (int)p.Quantity).GreaterThanOrEqualTo(0);
    }
}
