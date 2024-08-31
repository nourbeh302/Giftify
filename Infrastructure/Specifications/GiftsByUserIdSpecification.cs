using Domain.Gifts;

namespace Infrastructure.Specifications;

internal class GiftsByUserIdSpecification : Specification<Gift>
{
    public GiftsByUserIdSpecification(Guid createdById) : 
        base(gift => gift.CreatedBy.Id == createdById)
    {
        AddInclude(g => g.CreatedBy);
    }
}
