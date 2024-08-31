using Application.Gifts;
using Application.Products;
using Domain.Orders;
using FluentValidation.Results;
using MediatR;
using SharedKernel;
using SharedKernel.Dtos;
using SharedKernel.Errors;

namespace Application.Orders.UpdateOrder;

public record UpdateOrderCommand(
    Guid Id,
    UpdateAddressDto ShippingAddress,
    UpdateAddressDto BillingAddress,
    OrderStatus OrderStatus) :
    IRequest<Result<OrderResponse, Error>>;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Result<OrderResponse, Error>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IPublisher _publisher;

    public UpdateOrderCommandHandler(
        IOrderRepository orderRepository, 
        IPublisher publisher)
    {
        _orderRepository = orderRepository;
        _publisher = publisher;
    }

    public async Task<Result<OrderResponse, Error>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        UpdateOrderCommandValidator validator = new();

        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return OrderErrors.InvalidEntry;
        }

        Order? oldOrder = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);

        if (oldOrder is null)
        {
            return OrderErrors.OrderNotFound;
        }

        // Can not uncancel an order
        if (oldOrder.OrderStatus is OrderStatus.Cancelled &&
            request.OrderStatus is not OrderStatus.Cancelled)
        {
            return OrderErrors.OrderCancelled;
        }

        // Can not cancel a shipped order
        if (oldOrder.OrderStatus is OrderStatus.Shipped &&
            request.OrderStatus is OrderStatus.Cancelled)
        {
            return OrderErrors.OrderShipped;
        }

        // Prevent update for refunded orders
        if (oldOrder.OrderStatus is OrderStatus.Refunded)
        {
            return OrderErrors.OrderRefunded;
        }

        Address shippingAddress = new(
            id: request.ShippingAddress.Id,
            apartment: request.ShippingAddress.Apartment,
            floor: request.ShippingAddress.Floor,
            building: request.ShippingAddress.Building,
            street: request.ShippingAddress.Street,
            city: request.ShippingAddress.City,
            country: request.ShippingAddress.Country,
            governate: request.ShippingAddress.Governate,
            postalCode: request.ShippingAddress.PostalCode);

        Address billingAddress = new(
            id: request.BillingAddress.Id,
            apartment: request.BillingAddress.Apartment,
            floor: request.BillingAddress.Floor,
            building: request.BillingAddress.Building,
            street: request.BillingAddress.Street,
            city: request.BillingAddress.City,
            country: request.BillingAddress.Country,
            governate: request.BillingAddress.Governate,
            postalCode: request.BillingAddress.PostalCode);

        oldOrder = new(
            gifts: oldOrder.Gifts,
            id: oldOrder.Id,
            user: oldOrder.User,
            shippingAddress: shippingAddress,
            billingAddress: billingAddress,
            createdAtUtc: oldOrder.CreatedAtUtc,
            orderStatus: request.OrderStatus);

        Order order = await _orderRepository.UpdateAsync(oldOrder, cancellationToken);

        OrderUpdatedNotification notification = new(oldOrder);

        await _publisher.Publish(notification, cancellationToken);

        return new OrderResponse(
            Id: order.Id,
            User: order.User.Id,
            Gifts: order.Gifts
                .Select(g => new GiftResponse(
                    Id: g.Id,
                    Name: g.Name,
                    Description: g.Description,
                    CreatedById: g.CreatedBy.Id,
                    CreatedAtUtc: g.CreatedAtUtc,
                    TotalPrice: g.TotalPrice,
                    Products: g.Products
                        .Select(p => new ProductResponse(
                            Id: p.Id,
                            Title: p.Title,
                            Description: p.Description,
                            Price: p.Price,
                            AddedOnUtc: p.AddedOnUtc,
                            Quantity: p.Quantity,
                            Sku: p.Sku,
                            Category: Enum.GetName(p.Category)!))
                        .ToList()))
                .ToList(),
            ShippingAddress: order.ShippingAddress,
            BillingAddress: order.BillingAddress,
            CreatedAt: order.CreatedAtUtc,
            OrderStatus: Enum.GetName(order.OrderStatus)!,
            TotalPrice: order.TotalPrice);
    }
}
