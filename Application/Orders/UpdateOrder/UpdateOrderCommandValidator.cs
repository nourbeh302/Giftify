using Domain.Orders;
using FluentValidation;

namespace Application.Orders.UpdateOrder;

internal sealed class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(o => (int)o.OrderStatus)
            .InclusiveBetween(
                (int)OrderStatus.Pending, 
                (int)OrderStatus.OutForDelivery);
    }
}