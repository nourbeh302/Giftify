using Domain.Products;

namespace Infrastructure.Specifications;

internal class ReviewsByProductIdSpecification : Specification<Review>
{
    public ReviewsByProductIdSpecification(Guid productId) : 
        base(review => review.Product.Id == productId)
    {
        AddInclude(r => r.Product);
    }
}
