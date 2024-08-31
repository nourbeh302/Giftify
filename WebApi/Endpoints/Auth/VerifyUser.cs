using Application.Users.VerifyUser;
using MediatR;
using WebApi.Extensions;

namespace WebApi.Endpoints.Auth;

public class VerifyUser : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/auth/verify", async (
            ISender sender,
            VerifyUserCommand command) =>
        {
            var result = await sender.Send(command);

            return result.ToActionResult();
        })
            .WithDisplayName(nameof(VerifyUser))
            .WithTags(Tags.Auth);
    }
}
