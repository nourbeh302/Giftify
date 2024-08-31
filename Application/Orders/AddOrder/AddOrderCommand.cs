using Application.Gifts;
using Application.Products;
using Domain.Gifts;
using Domain.Orders;
using Domain.Users;
using FluentValidation.Results;
using MediatR;
using SharedKernel;
using SharedKernel.Dtos;
using SharedKernel.Errors;

namespace Application.Orders.AddOrder;

public record AddOrderCommand(
    List<Guid> GiftIds,
    Guid UserId,
    AddAddressDto ShippingAddress,
    AddAddressDto BillingAddress) :
    IRequest<Result<OrderResponse, Error>>;

public class AddOrderCommandHandler(
    IOrderRepository orderRepository,
    IUserRepository userRepository,
    IGiftRepository giftRepository,
    IPublisher publisher) :
    IRequestHandler<AddOrderCommand, Result<OrderResponse, Error>>
{
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IGiftRepository _giftRepository = giftRepository;
    private readonly IPublisher _publisher = publisher;

    public async Task<Result<OrderResponse, Error>> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        AddOrderCommandValidator validator = new();

        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return OrderErrors.InvalidEntry;
        }

        User? user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null)
        {
            return UserErrors.UserNotFound;
        }

        Address shippingAddress = new(
            id: Guid.NewGuid(),
            apartment: request.ShippingAddress.Apartment,
            floor: request.ShippingAddress.Floor,
            building: request.ShippingAddress.Building,
            street: request.ShippingAddress.Street,
            city: request.ShippingAddress.City,
            country: request.ShippingAddress.Country,
            governate: request.ShippingAddress.Governate,
            postalCode: request.ShippingAddress.PostalCode);

        Address billingAddress = new(
            id: Guid.NewGuid(),
            apartment: request.BillingAddress.Apartment,
            floor: request.BillingAddress.Floor,
            building: request.BillingAddress.Building,
            street: request.BillingAddress.Street,
            city: request.BillingAddress.City,
            country: request.BillingAddress.Country,
            governate: request.BillingAddress.Governate,
            postalCode: request.BillingAddress.PostalCode);

        Order newOrder = new(
            gifts: [],
            id: Guid.NewGuid(),
            user: user,
            shippingAddress: shippingAddress,
            billingAddress: billingAddress,
            createdAtUtc: DateTime.UtcNow,
            orderStatus: OrderStatus.Pending);

        foreach (Guid giftId in request.GiftIds)
        {
            Gift? gift = await _giftRepository.GetByIdAsync(giftId, cancellationToken);

            newOrder.AddGift(gift!);
        }

        Order order = await _orderRepository.AddAsync(newOrder, cancellationToken);

        OrderAddedNotification notification = new(order);

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
