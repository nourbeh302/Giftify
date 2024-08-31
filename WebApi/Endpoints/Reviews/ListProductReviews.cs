using Application.Products.ListProductReviews;
using MediatR;
using WebApi.Extensions;

namespace WebApi.Endpoints.Reviews;

public class ListProductReviews : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}/reviews", async (
            ISender sender,
            Guid id,
            int? pageSize,
            int? pageIndex) => 
        {
            var result = await sender.Send(new ListProductReviewsQuery(id, pageSize, pageIndex));

            return result.ToActionResult();
        })
            .WithDisplayName(nameof(ListProductReviews))
            .WithTags(Tags.Reviews);
    }
}
