using Application.Orders.GetOrderById;
using MediatR;
using WebApi.Extensions;

namespace WebApi.Endpoints.Orders;

public class GetOrderById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/{id}", async (
            ISender sender,
            Guid id) =>
        {
            var result = await sender.Send(new GetOrderByIdQuery(id));

            return result.ToActionResult();
        })
            .WithDisplayName(nameof(GetOrderById))
            .WithTags(Tags.Orders);
    }
}