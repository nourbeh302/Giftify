using Domain.Gifts;
using Domain.Products;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class GiftRepository(ApplicationDbContext dbContext) : IGiftRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<Gift> AddAsync(Gift gift, CancellationToken cancellationToken = default)
    {
        _dbContext.Entry(gift.CreatedBy).State = EntityState.Unchanged;

        gift.Products.ForEach(product => _dbContext.Entry(product).State = EntityState.Unchanged);

        await _dbContext.Gifts.AddAsync(gift, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return gift;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _dbContext.Gifts
            .Include(g => g.CreatedBy)
            .Where(g => g.Id == id)
            .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<Gift?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Gifts
            .Include(g => g.CreatedBy)
            .Include(g => g.Products)
            .FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Gift>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Gifts
            .Include(g => g.CreatedBy)
            .Include(g => g.Products)
            .ToListAsync(cancellationToken);
    }

    public async Task<Gift> UpdateAsync(Gift gift, CancellationToken cancellationToken = default)
    {
        Gift trackedGift = await _dbContext.Gifts
            .Include(g => g.Products)
            .FirstAsync(g => g.Id == gift.Id, cancellationToken);

        _dbContext.Entry(trackedGift).State = EntityState.Detached;

        _dbContext.Entry(gift).State = EntityState.Modified;

        foreach (var product in gift.Products)
        {
            _dbContext.Entry(product).State = EntityState.Unchanged;
        }

        await _dbContext.SaveChangesAsync(cancellationToken);

        return trackedGift;
    }
}
