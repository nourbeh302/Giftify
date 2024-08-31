using Application.Products.AddReview;
using Domain.Products;
using MediatR;
using System.Security.Claims;
using WebApi.Extensions;

namespace WebApi.Endpoints.Reviews;

public class AddReview : IEndpoint
{
    public record AddReviewDto(
        Rating Rating,
        string? Comment,
        Guid ProductId);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/reviews", async (
            ISender sender,
            HttpContext context,
            AddReviewDto dto) =>
        {
            Claim? userIdClaim = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            Guid.TryParse(userIdClaim!.Value, out Guid parsedUserId);

            AddReviewCommand command = new(
                AddedById: parsedUserId,
                ProductId: dto.ProductId,
                Rating: dto.Rating,
                Comment: dto.Comment);

            var result = await sender.Send(command);

            return result.ToActionResult();
        })
            .RequireAuthorization()
            .WithDisplayName(nameof(AddReview))
            .WithTags(Tags.Reviews);
    }
}

