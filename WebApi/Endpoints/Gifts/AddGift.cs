using Application.Gifts.AddGift;
using MediatR;
using System.Security.Claims;
using WebApi.Extensions;

namespace WebApi.Endpoints.Gifts;

public class AddGift : IEndpoint
{
    internal record AddGiftDto(
        string Name,
        string Description,
        List<Guid> ProductIds);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/gifts", async (
            ISender sender,
            HttpContext context,
            AddGiftDto dto) =>
        {

            Claim? userIdClaim = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            Guid.TryParse(userIdClaim!.Value, out Guid parsedUserId);

            AddGiftCommand command = new(
                Name: dto.Name, 
                Description: dto.Description,
                CreatedById: parsedUserId,
                ProductIds: dto.ProductIds);

            var result = await sender.Send(command);

            return result.ToActionResult();
        })
            .RequireAuthorization()
            .WithDisplayName(nameof(AddGift))
            .WithTags(Tags.Gifts);
    }
}
