using Domain.Gifts;
using Domain.Orders;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

internal sealed class OrderRepository(ApplicationDbContext dbContext) : IOrderRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<Order> AddAsync(Order order, CancellationToken cancellationToken = default)
    {
        _dbContext.Entry(order.User).State = EntityState.Unchanged;

        foreach (var gift in order.Gifts)
        {
            _dbContext.Entry(gift).State = EntityState.Unchanged;
        }

        await _dbContext.Orders.AddAsync(order, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return order;
    }

    public async Task<Order?> FindAsync(Expression<Func<Order, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Orders
            .AsSplitQuery()
            .Include(o => o.Gifts)
            .Include(o => o.User)
            .Include(o => o.ShippingAddress)
            .Include(o => o.BillingAddress)
            .FirstOrDefaultAsync(expression, cancellationToken);
    }

    public async Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Orders
            .AsSplitQuery()
            .Include(o => o.Gifts)
            .Include(o => o.User)
            .Include(o => o.ShippingAddress)
            .Include(o => o.BillingAddress)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Order>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Orders
            .AsSplitQuery()
            .Include(o => o.Gifts)
            .Include(o => o.User)
            .Include(o => o.ShippingAddress)
            .Include(o => o.BillingAddress)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Order>> ListAsync(Expression<Func<Order, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Orders
            .Where(expression)
            .AsSplitQuery()
            .Include(o => o.Gifts)
            .Include(o => o.User)
            .Include(o => o.ShippingAddress)
            .Include(o => o.BillingAddress)
            .ToListAsync(cancellationToken);
    }

    public async Task<Order> UpdateAsync(Order order, CancellationToken cancellationToken = default)
    {
        await _dbContext.Addresses
            .Where(a => a.Id == order.ShippingAddressId)
            .ExecuteUpdateAsync(
                s => s
                    .SetProperty(a => a.Apartment, order.ShippingAddress.Apartment)
                    .SetProperty(a => a.Floor, order.ShippingAddress.Floor)
                    .SetProperty(a => a.Building, order.ShippingAddress.Building)
                    .SetProperty(a => a.City, order.ShippingAddress.City)
                    .SetProperty(a => a.Country, order.ShippingAddress.PostalCode)
                    .SetProperty(a => a.Governate, order.ShippingAddress.Governate)
                    .SetProperty(a => a.PostalCode, order.ShippingAddress.PostalCode),
                cancellationToken);
        
        await _dbContext.Addresses
            .Where(a => a.Id == order.BillingAddressId)
            .ExecuteUpdateAsync(
                s => s
                    .SetProperty(a => a.Apartment, order.BillingAddress.Apartment)
                    .SetProperty(a => a.Floor, order.BillingAddress.Floor)
                    .SetProperty(a => a.Building, order.BillingAddress.Building)
                    .SetProperty(a => a.City, order.BillingAddress.City)
                    .SetProperty(a => a.Country, order.BillingAddress.PostalCode)
                    .SetProperty(a => a.Governate, order.BillingAddress.Governate)
                    .SetProperty(a => a.PostalCode, order.BillingAddress.PostalCode),
                cancellationToken);

        await _dbContext.Orders
            .Where(o => o.Id == order.Id)
            .ExecuteUpdateAsync(
                s => s
                    .SetProperty(o => o.OrderStatus, order.OrderStatus),
                cancellationToken);

        return order;
    }
}
