using System.Linq.Expressions;

namespace Domain.Products;

public interface IReviewRepository
{
    Task<Review> AddAsync(Review review, CancellationToken cancellationToken = default);
    Task<Review> UpdateAsync(Review review, CancellationToken cancellationToken = default);
    Task<Review?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Review>> FindAsync(Expression<Func<Review, bool>> expression, CancellationToken cancellationToken = default);
}