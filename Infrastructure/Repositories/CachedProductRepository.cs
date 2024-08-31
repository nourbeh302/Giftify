using Domain.Products;
using Microsoft.Extensions.Caching.Memory;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

internal sealed class CachedProductRepository(
    ProductRepository decorated,
    IMemoryCache memoryCache) :
    IProductRepository
{
    private readonly ProductRepository _decorated = decorated;
    private readonly IMemoryCache _memoryCache = memoryCache;

    public Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        return _decorated.AddAsync(product, cancellationToken);
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _decorated.DeleteAsync(id, cancellationToken);
    }

    public Task<IReadOnlyList<Product>> FindAsync(Expression<Func<Product, bool>> expression, CancellationToken cancellationToken = default)
    {
        return _decorated.FindAsync(expression, cancellationToken);
    }

    public Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        string key = $"product-{id}";

        return _memoryCache.GetOrCreateAsync(
             key,
             entry =>
             {
                 entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

                 return _decorated.GetByIdAsync(id, cancellationToken);
             });
    }

    public Task<IReadOnlyList<Product>> ListAsync(CancellationToken cancellationToken = default)
    {
        return _decorated.ListAsync(cancellationToken);
    }

    public Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        return _decorated.UpdateAsync(product, cancellationToken);
    }
}
