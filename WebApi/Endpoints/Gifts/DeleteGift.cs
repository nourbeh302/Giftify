using Application.Gifts.DeleteGift;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;
using System.Security.Claims;
using WebApi.Extensions;

namespace WebApi.Endpoints.Gifts;

public class DeleteGift : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/gifts/{id}", async (
            ISender sender,
            Guid id,
            HttpContext context) =>
        {

            Claim? userIdClaim = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            Guid.TryParse(userIdClaim!.Value, out Guid parsedUserId);

            DeleteGiftCommand command = new(
                Id: id,
                CreatedById: parsedUserId);

            var result = await sender.Send(command);

            return result.ToActionResult();
        })
            .RequireAuthorization()
            .WithDisplayName(nameof(DeleteGift))
            .WithTags(Tags.Gifts);
    }
}
