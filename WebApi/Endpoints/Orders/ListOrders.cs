using Application.Orders.ListOrders;
using MediatR;
using WebApi.Extensions;

namespace WebApi.Endpoints.Orders;

public class ListOrders : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders", async (
            ISender sender,
            int? pageSize,
            int? pageIndex) =>
        {
            var result = await sender.Send(new ListOrdersQuery(pageSize, pageIndex));

            return result.ToActionResult();
        })
            .WithDisplayName(nameof(ListOrders))
            .WithTags(Tags.Orders);
    }
}
