using Application.Orders.UpdateOrder;
using Domain.Orders;
using MediatR;
using SharedKernel.Dtos;
using WebApi.Extensions;

namespace WebApi.Endpoints.Orders;

public class UpdateOrder : IEndpoint
{
    internal record UpdateOrderDto(
        UpdateAddressDto ShippingAddress,
        UpdateAddressDto BillingAddress,
        OrderStatus OrderStatus);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPatch("/orders/{id}", async (
            ISender sender,
            Guid id,
            UpdateOrderDto dto) =>
        {
            UpdateOrderCommand command = new(
                Id: id,
                ShippingAddress: dto.ShippingAddress,
                BillingAddress: dto.BillingAddress,
                OrderStatus: dto.OrderStatus);

            var result = await sender.Send(command);

            return result.ToActionResult();
        })
            .WithDisplayName(nameof(UpdateOrder))
            .WithTags(Tags.Orders);
    }
}
