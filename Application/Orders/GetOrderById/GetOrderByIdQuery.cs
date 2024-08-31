using Application.Gifts;
using Application.Products;
using Domain.Orders;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;

namespace Application.Orders.GetOrderById;

public record GetOrderByIdQuery(Guid Id) : 
    IRequest<Result<OrderResponse, Error>>;

public class GetOrderByIdQueryHandler : 
    IRequestHandler<GetOrderByIdQuery, Result<OrderResponse, Error>>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Result<OrderResponse, Error>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        Order? order = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);

        if (order is null)
        {
            return OrderErrors.OrderNotFound;
        }

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
