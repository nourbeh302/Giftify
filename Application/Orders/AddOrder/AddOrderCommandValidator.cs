using FluentValidation;

namespace Application.Orders.AddOrder;

internal sealed class AddOrderCommandValidator : AbstractValidator<AddOrderCommand>
{
    public AddOrderCommandValidator()
    {
        RuleFor(o => o.BillingAddress.City)
            .MinimumLength(4);

        RuleFor(o => o.ShippingAddress.Country)
            .MinimumLength(4);
    }
}
