using Domain.Products;
using Microsoft.Extensions.Caching.Memory;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

internal sealed class CachedReviewRepository(
    ReviewRepository decorated,
    IMemoryCache memoryCache) :
    IReviewRepository
{
    private readonly ReviewRepository _decorated = decorated;
    private readonly IMemoryCache _memoryCache = memoryCache;

    public Task<Review> AddAsync(Review review, CancellationToken cancellationToken = default)
    {
        return _decorated.AddAsync(review, cancellationToken);
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _decorated.DeleteAsync(id, cancellationToken);
    }

    public Task<Review?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        string key = $"review-{id}";

        return _memoryCache.GetOrCreateAsync(
            key,
            entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

                return _decorated.GetByIdAsync(id, cancellationToken);
            });
    }

    public Task<IReadOnlyList<Review>> FindAsync(Expression<Func<Review, bool>> expression, CancellationToken cancellationToken = default)
    {
        return _decorated.FindAsync(expression, cancellationToken);
    }

    public Task<Review> UpdateAsync(Review review, CancellationToken cancellationToken = default)
    {
        return _decorated.UpdateAsync(review, cancellationToken);
    }
}
