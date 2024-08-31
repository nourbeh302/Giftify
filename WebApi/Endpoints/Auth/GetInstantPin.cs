using Application.Users.GetSingleUsePin;
using MediatR;
using WebApi.Extensions;

namespace WebApi.Endpoints.Auth;

public class GetInstantPin : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/auth/pin", async (
            ISender sender,
            GetInstantPinCommand command) =>
        {
            var result = await sender.Send(command);

            return result.ToActionResult();
        })
            .WithDisplayName(nameof(GetInstantPin))
            .WithTags(Tags.Auth);
    }
}
