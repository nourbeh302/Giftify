using Application.Users.Register;
using Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

namespace WebApi.Endpoints.Auth;

public class Register : IEndpoint
{
    public record RegisterDto(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string PhoneNumber,
        string Address,
        Gender Gender);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/auth/register", async (
            RegisterDto dto,
            [FromServices] ISender sender) =>
        {
            RegisterCommand command = new(
                FirstName: dto.FirstName,
                LastName: dto.LastName,
                Email: dto.Email,
                PasswordHash: dto.Password,
                PhoneNumber: dto.PhoneNumber,
                Gender: dto.Gender,
                Address: dto.Address);

            var result = await sender.Send(command);

            return result.ToActionResult();
        })
            .WithDisplayName(nameof(Register))
            .WithTags(Tags.Auth);
    }
}
