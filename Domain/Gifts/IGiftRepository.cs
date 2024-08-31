namespace Domain.Gifts;

public interface IGiftRepository
{
    Task<Gift> AddAsync(Gift gift, CancellationToken cancellationToken = default);
    Task<Gift> UpdateAsync(Gift gift, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Gift>> ListAsync(CancellationToken cancellationToken = default);
    Task<Gift?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}