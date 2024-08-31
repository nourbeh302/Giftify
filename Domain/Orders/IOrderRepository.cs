using System.Linq.Expressions;

namespace Domain.Orders;

public interface IOrderRepository
{
    Task<Order> AddAsync(Order order, CancellationToken cancellationToken = default);
    Task<Order> UpdateAsync(Order order, CancellationToken cancellationToken = default);
    Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Order?> FindAsync(Expression<Func<Order, bool>> expression, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Order>> ListAsync(Expression<Func<Order, bool>> expression, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Order>> ListAsync(CancellationToken cancellationToken = default);
}