using Application.Users;
using Application.Users.GetUserById;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;
using System.Security.Claims;
using WebApi.Extensions;

namespace WebApi.Endpoints.Users;

public class GetProfile : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/users/profile", async (
            HttpContext context, 
            ISender sender) =>
        {
            Claim? userIdClaim = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            Guid.TryParse(userIdClaim!.Value, out Guid parsedUserId);

            Result<UserResponse, Error> result = await sender.Send(new GetUserByIdQuery(parsedUserId));

            return result.ToActionResult();
        })
            .RequireAuthorization()
            .WithDisplayName(nameof(GetProfile))
            .WithTags(Tags.Users);
    }
}
