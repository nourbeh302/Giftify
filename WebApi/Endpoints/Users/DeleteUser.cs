using Application.Users.DeleteUser;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;
using WebApi.Extensions;

namespace WebApi.Endpoints.Users;

public class DeleteUser : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/users/{id}", async (Guid id, ISender sender) =>
        {
            DeleteUserCommand command = new(id);
            
            Result<int, Error> result = await sender.Send(command);

            return result.ToActionResult();
        })
            .WithDisplayName(nameof(DeleteUser))
            .WithTags(Tags.Users);
    }
}
