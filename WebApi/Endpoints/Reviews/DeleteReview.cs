using Application.Products.DeleteReview;
using MediatR;
using WebApi.Extensions;

namespace WebApi.Endpoints.Reviews;

public class DeleteReview : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/reviews/{id}", async (
            ISender sender,
            Guid id) =>
        {
            var result = await sender.Send(new DeleteReviewCommand(id));

            return result.ToActionResult();
        })
            .RequireAuthorization()
            .WithDisplayName(nameof(DeleteReview))
            .WithTags(Tags.Reviews);
    }
}

