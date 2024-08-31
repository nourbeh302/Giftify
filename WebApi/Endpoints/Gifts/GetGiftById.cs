using Application.Gifts.GetGiftById;
using MediatR;
using WebApi.Extensions;

namespace WebApi.Endpoints.Gifts;

public class GetGiftById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/gifts/{id}", async (ISender sender, Guid id) =>
        {
            var result = await sender.Send(new GetGiftByIdQuery(id));

            return result.ToActionResult();
        })
            .WithDisplayName(nameof(GetGiftById))
            .WithTags(Tags.Gifts);
    }
}
