using Application.Products;
using Domain.Products;
using Domain.Users;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;

namespace Application.Products.AddReview;

public record AddReviewCommand(
    Guid AddedById,
    Guid ProductId,
    Rating Rating,
    string? Comment) :
    IRequest<Result<ReviewResponse, Error>>;

public class AddReviewCommandHandler :
    IRequestHandler<AddReviewCommand, Result<ReviewResponse, Error>>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;

    public AddReviewCommandHandler(
        IReviewRepository reviewRepository,
        IUserRepository userRepository,
        IProductRepository productRepository)
    {
        _reviewRepository = reviewRepository;
        _userRepository = userRepository;
        _productRepository = productRepository;
    }

    public async Task<Result<ReviewResponse, Error>> Handle(AddReviewCommand request, CancellationToken cancellationToken)
    {
        User? addedBy = await _userRepository.GetByIdAsync(request.AddedById, cancellationToken);

        if (addedBy is null)
        {
            return UserErrors.UserNotFound;
        }

        Product? product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);

        if (product is null)
        {
            return ProductErrors.ProductNotFound;
        }

        Review newReview = new(
            id: Guid.NewGuid(),
            addedOnUtc: DateTime.UtcNow,
            addedBy: addedBy,
            product: product,
            rating: request.Rating,
            comment: request.Comment);

        Review review = await _reviewRepository.AddAsync(newReview, cancellationToken);

        return new ReviewResponse(
            Id: review.Id,
            Comment: newReview.Comment,
            Rating: (uint)review.Rating,
            AddedById: review.AddedBy.Id,
            ProductId: review.Product.Id);
    }
}
