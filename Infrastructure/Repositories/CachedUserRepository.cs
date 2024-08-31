using Domain.Users;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repositories;

internal sealed class CachedUserRepository(
    UserRepository decorated,
    IMemoryCache memoryCache) : 
    IUserRepository
{
    private readonly UserRepository _decorated = decorated;
    private readonly IMemoryCache _memoryCache = memoryCache;

    public Task<User> AddAsync(User user, CancellationToken cancellationToken = default)
    {
        return _decorated.AddAsync(user, cancellationToken);
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _decorated.DeleteAsync(id, cancellationToken);
    }

    public Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return _decorated.GetByEmailAsync(email, cancellationToken);
    }

    public Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        //string key = $"user-{id}";

        //return _memoryCache.GetOrCreateAsync(
        //    key,
        //    entry =>
        //    {
        //        entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

        //        return _decorated.GetByIdAsync(id, cancellationToken);
        //    });

        return _decorated.GetByIdAsync(id, cancellationToken);
    }

    public Task<IReadOnlyList<User>> ListAsync(CancellationToken cancellationToken = default)
    {
        return _decorated.ListAsync(cancellationToken);
    }

    public Task<User> UpdateAsync(User user, CancellationToken cancellationToken = default)
    {
        return _decorated.UpdateAsync(user, cancellationToken);
    }
}
