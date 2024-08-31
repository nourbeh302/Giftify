using Application.Users.UpdateUser;
using Domain.Users;
using MediatR;
using System.Security.Claims;
using WebApi.Extensions;

namespace WebApi.Endpoints.Auth;

public class UpdateProfile : IEndpoint
{
    public record UpdateUserDto(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string PhoneNumber,
        string Address,
        Gender Gender);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPatch("/users/{id}", async (
            ISender sender, 
            HttpContext context,
            UpdateUserDto dto) =>
        {
            Claim? userIdClaim = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            Guid.TryParse(userIdClaim!.Value, out Guid parsedUserId);

            UpdateProfileCommand command = new(
                Id: parsedUserId,
                FirstName: dto.FirstName,
                LastName: dto.LastName,
                Email: dto.Email,
                PhoneNumber: dto.PhoneNumber,
                Gender: dto.Gender,
                Address: dto.Address);

            var result = await sender.Send(command);

            return result.ToActionResult();
        })
            .RequireAuthorization()
            .WithDisplayName(nameof(UpdateProfile))
            .WithTags(Tags.Users);
    }
}
