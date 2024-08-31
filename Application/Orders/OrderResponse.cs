using Application.Gifts;
using Domain.Orders;

namespace Application.Orders;

public record OrderResponse(
    Guid Id,
    Guid User,
    List<GiftResponse> Gifts,
    Address ShippingAddress,
    Address BillingAddress,
    DateTime CreatedAt,
    string OrderStatus,
    double TotalPrice);