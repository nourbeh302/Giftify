using Application.Users.ListUserOrders;
using MediatR;
using System.Security.Claims;
using WebApi.Extensions;

namespace WebApi.Endpoints.Orders;

public class ListUserOrders : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/users/orders", async (
            ISender sender,
            HttpContext context,
            int? pageSize,
            int? pageIndex) =>
        {
            Claim? userIdClaim = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            Guid.TryParse(userIdClaim!.Value, out Guid parsedUserId);

            var result = await sender.Send(new ListUserOrdersQuery(parsedUserId, pageSize, pageIndex));

            return result.ToActionResult();
        })
            .WithDisplayName(nameof(ListUserOrders))
            .WithTags(Tags.Orders);
    }
}
