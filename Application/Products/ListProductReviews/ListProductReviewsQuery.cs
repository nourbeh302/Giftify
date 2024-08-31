using Application.Common;
using Domain.Products;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;
using System.Linq.Expressions;

namespace Application.Products.ListProductReviews;

public record ListProductReviewsQuery(
    Guid ProductId,
    int? PageSize,
    int? PageIndex) :
    IRequest<Result<PagedList<ReviewResponse>, Error>>;

public class ListProductReviewsQueryHandler :
    IRequestHandler<ListProductReviewsQuery, Result<PagedList<ReviewResponse>, Error>>
{
    private readonly IProductRepository _productRepository;
    private readonly IReviewRepository _reviewRepository;

    public ListProductReviewsQueryHandler(
        IProductRepository productRepository,
        IReviewRepository reviewRepository)
    {
        _productRepository = productRepository;
        _reviewRepository = reviewRepository;
    }

    public async Task<Result<PagedList<ReviewResponse>, Error>> Handle(ListProductReviewsQuery request, CancellationToken cancellationToken)
    {
        int pageSize = request.PageSize ?? 4;
        int pageIndex = request.PageIndex ?? 1;

        Product? product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);

        if (product is null)
        {
            return ProductErrors.ProductNotFound;
        }

        Expression<Func<Review, bool>> expression = r => r.Product.Id == product.Id;

        IReadOnlyList<Review> reviews = await _reviewRepository.FindAsync(expression, cancellationToken);

        IEnumerable<ReviewResponse> reviewResponses = reviews.Select(r => new ReviewResponse(
            Id: r.Id,
            Comment: r.Comment,
            Rating: (uint)r.Rating,
            AddedById: r.AddedBy.Id,
            ProductId: r.Product.Id));

        PagedList<ReviewResponse> pagedList = PagedList<ReviewResponse>.Create(
            list: reviewResponses,
            pageSize: pageSize,
            pageIndex: pageIndex);

        return pagedList;
    }
}
