using Domain.Products;

namespace Infrastructure.Specifications;

internal class ReviewsByUserIdSpecification : Specification<Review>
{
    public ReviewsByUserIdSpecification(Guid addedById) : 
        base(review => review.AddedBy.Id == addedById)
    {
        AddInclude(r => r.AddedBy);
    }
}
