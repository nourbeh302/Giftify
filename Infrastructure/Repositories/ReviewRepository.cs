using Domain.Products;
using Domain.Users;
using Infrastructure.Data;
using Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

internal sealed class ReviewRepository(ApplicationDbContext dbContext) : IReviewRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<Review> AddAsync(Review review, CancellationToken cancellationToken = default)
    {
        await _dbContext.Reviews.AddAsync(review, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return review;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _dbContext.Reviews
            .Where(r => r.Id == id)
            .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<Review?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Reviews.FirstOrDefaultAsync(r => r.Id == id, cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyList<Review>> ListByUserIdAsync(User addedBy, CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(new ReviewsByUserIdSpecification(addedBy.Id))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Review>> FindAsync(Expression<Func<Review, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Reviews
            .Include(r => r.Product)
            .Where(expression)
            .ToListAsync(cancellationToken);
    }

    public async Task<Review> UpdateAsync(Review review, CancellationToken cancellationToken = default)
    {
        await _dbContext.Reviews
            .Where(r => r.Id == review.Id)
            .ExecuteUpdateAsync(
                s => s
                    .SetProperty(r => r.AddedBy, review.AddedBy)
                    .SetProperty(r => r.Rating, review.Rating)
                    .SetProperty(r => r.Comment, review.Comment),
                cancellationToken: cancellationToken);

        return review;
    }

    private IQueryable<Review> ApplySpecification(Specification<Review> specification)
    {
        return SpecificationEvaluator.GetQuery(
            _dbContext.Reviews,
            specification);
    }
}
