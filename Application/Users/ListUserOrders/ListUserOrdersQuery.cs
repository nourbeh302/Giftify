using Application.Common;
using Application.Gifts;
using Application.Orders;
using Application.Products;
using Domain.Orders;
using Domain.Users;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;
using System.Linq.Expressions;

namespace Application.Users.ListUserOrders;

public record ListUserOrdersQuery(
    Guid UserId,
    int? PageSize,
    int? PageIndex) : 
    IRequest<Result<PagedList<OrderResponse>, Error>>;

public class ListUserOrdersQueryHandler : 
    IRequestHandler<ListUserOrdersQuery, Result<PagedList<OrderResponse>, Error>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;

    public ListUserOrdersQueryHandler(
        IOrderRepository orderRepository,
        IUserRepository userRepository)
    {
        _orderRepository = orderRepository;
        _userRepository = userRepository;
    }

    public async Task<Result<PagedList<OrderResponse>, Error>> Handle(ListUserOrdersQuery request, CancellationToken cancellationToken)
    {
        int pageSize = request.PageSize ?? 4;
        int pageIndex = request.PageIndex ?? 1;

        User? user  = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null)
        {
            return UserErrors.UserNotFound;
        }

        Expression<Func<Order, bool>> expression = o => o.User.Id == user.Id;

        IReadOnlyList<Order> orders = await _orderRepository.ListAsync(expression, cancellationToken);

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