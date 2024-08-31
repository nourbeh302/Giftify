using Application.Orders.AddOrder;
using MediatR;
using System.Security.Claims;
using WebApi.Extensions;
using SharedKernel.Dtos;

namespace WebApi.Endpoints.Orders;

public class AddOrder : IEndpoint
{
    internal record AddOrderDto(
        List<Guid> GiftIds,
        AddAddressDto ShippingAddress,
        AddAddressDto BillingAddress);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/orders", async (
            ISender sender,
            HttpContext context,
            AddOrderDto dto) =>
        {
            Claim? userIdClaim = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            Guid.TryParse(userIdClaim!.Value, out Guid parsedUserId);

            AddOrderCommand command = new(
                GiftIds: dto.GiftIds,
                UserId: parsedUserId,
                ShippingAddress: dto.ShippingAddress,
                BillingAddress: dto.BillingAddress);

            var result = await sender.Send(command);

            return result.ToActionResult();
        })
            .RequireAuthorization()
            .WithDisplayName(nameof(AddOrder))
            .WithTags(Tags.Orders);
    }
}
