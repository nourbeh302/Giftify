using Domain.Gifts;
using Domain.Users;

namespace Domain.Orders;

public class Order
{
    private readonly List<Gift> _gifts = [];

    public Order()
    {
    }

    public Order(
        List<Gift> gifts,
        Guid id,
        User user,
        Address shippingAddress,
        Address billingAddress,
        DateTime createdAtUtc,
        OrderStatus orderStatus)
    {
        _gifts = gifts;
        Id = id;
        User = user;
        ShippingAddressId = shippingAddress.Id;
        ShippingAddress = shippingAddress;
        BillingAddressId = billingAddress.Id;
        BillingAddress = billingAddress;
        CreatedAtUtc = createdAtUtc;
        OrderStatus = orderStatus;
    }

    public Guid Id { get; private set; }
    public User User { get; private set; } = new();
    public List<Gift> Gifts => _gifts;
    public Guid ShippingAddressId { get; private set; } 
    public Address ShippingAddress { get; private set; } = new();
    public Guid BillingAddressId { get; private set; }
    public Address BillingAddress { get; private set; } = new();
    public DateTime CreatedAtUtc { get; private set; }
    public OrderStatus OrderStatus { get; private set; }
    public double TotalPrice => _gifts.Sum(gift => gift.Products.Sum(product => product.Price));

    public void AddGift(Gift gift)
    {
        _gifts.Add(gift);
    }

    public void RemoveGift(Gift gift)
    {
        _gifts.Remove(gift);
    }
}

public enum OrderStatus
{
    Pending,
    Delivered,
    Cancelled,
    Shipped,
    Processing,
    Returned,
    Refunded,
    AwaitingPayment,
    OutForDelivery
}
