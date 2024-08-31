using Application.Users;
using Application.Users.Login;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;
using WebApi.Extensions;

namespace WebApi.Endpoints.Auth;

public class Login : IEndpoint
{
    internal record LoginDto(
        string Email,
        string Password);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/auth/login", async (LoginDto dto, ISender sender) =>
        {
            LoginCommand command = new(dto.Email, dto.Password);

            var result = await sender.Send(command);
            
            return result.ToActionResult();
        })
            .WithDisplayName(nameof(Login))
            .WithTags(Tags.Auth);
    }
}
