using Domain.Products;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;

namespace Application.Products.DeleteReview;

public record DeleteReviewCommand(Guid Id) : IRequest<Result<int, Error>>;

public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, Result<int, Error>>
{
    private readonly IReviewRepository _reviewRepository;

    public DeleteReviewCommandHandler(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<Result<int, Error>> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        Review? review = await _reviewRepository.GetByIdAsync(request.Id, cancellationToken);

        if (review is null)
        {
            return ReviewErrors.ReviewNotFound;
        }

        await _reviewRepository.DeleteAsync(review.Id, cancellationToken);

        return 1;
    }
}
