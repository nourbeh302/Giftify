using FluentValidation;

namespace Application.Products.AddReview;

public class AddReviewCommandValidator : AbstractValidator<AddReviewCommand>
{
    public AddReviewCommandValidator()
    {
        RuleFor(r => (int)r.Rating).ExclusiveBetween(1, 5);
    }
}