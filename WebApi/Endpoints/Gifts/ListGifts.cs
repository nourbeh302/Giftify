using Application.Gifts.ListGifts;
using MediatR;
using WebApi.Extensions;

namespace WebApi.Endpoints.Gifts;

public class ListGifts : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/gifts", async (
            ISender sender,
            int? pageSize,
            int? pageIndex) =>
        {
            var result = await sender.Send(new ListGiftsQuery(pageSize, pageIndex));

            return result.ToActionResult();
        })
            .WithDisplayName(nameof(ListGifts))
            .WithTags(Tags.Gifts);
    }
}
