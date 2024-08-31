using Application.Common;
using Application.Gifts;
using Application.Products;
using Domain.Orders;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;

namespace Application.Orders.ListOrders;

public record ListOrdersQuery(int? PageSize, int? PageIndex) :
    IRequest<Result<PagedList<OrderResponse>, Error>>;

public class ListOrdersQueryHandler(IOrderRepository orderRepository) :
    IRequestHandler<ListOrdersQuery, Result<PagedList<OrderResponse>, Error>>
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task<Result<PagedList<OrderResponse>, Error>> Handle(ListOrdersQuery request, CancellationToken cancellationToken)
    {
        int pageSize = request.PageSize ?? 4;
        int pageIndex = request.PageIndex ?? 1;

        IReadOnlyList<Order> orders = await _orderRepository.ListAsync(cancellationToken);

        IEnumerable<OrderResponse> orderResponses = orders
            .Select(o => new OrderResponse(
                Id: o.Id,
                User: o.User.Id,
                Gifts: o.Gifts
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
                ShippingAddress: o.ShippingAddress,
                BillingAddress: o.BillingAddress,
                CreatedAt: o.CreatedAtUtc,
                OrderStatus: Enum.GetName(o.OrderStatus)!,
                TotalPrice: o.TotalPrice));

        PagedList<OrderResponse> pagedList = PagedList<OrderResponse>.Create(
            list: orderResponses,
            pageSize: pageSize,
            pageIndex: pageIndex);

        return pagedList;
    }
}
