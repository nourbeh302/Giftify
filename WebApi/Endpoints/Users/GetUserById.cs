using Application.Users;
using Application.Users.GetUserById;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;
using WebApi.Extensions;

namespace WebApi.Endpoints.Users;

public class GetUserById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/users/{id}", async (
            ISender sender,
            Guid id) =>
        {
            Result<UserResponse, Error> result = await sender.Send(new GetUserByIdQuery(id));

            return result.ToActionResult();
        })
            .WithDisplayName(nameof(GetProfile))
            .WithTags(Tags.Users);
    }
}
