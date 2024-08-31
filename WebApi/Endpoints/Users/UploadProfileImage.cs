using Application.Users.UploadProfileImage;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;
using System.Security.Claims;
using WebApi.Extensions;
using WebApi.Helpers;

namespace WebApi.Endpoints.Users;

public class UploadProfileImage : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/users/profile/upload", async (
            ISender sender,
            HttpContext context,
            IFileManager fileManager,
            IFormFile file,
            IWebHostEnvironment environment) =>
        {
            Claim? userIdClaim = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            Guid.TryParse(userIdClaim!.Value, out Guid parsedUserId);

            await fileManager.SaveAsync(file);

            string fileName = fileManager.GetFileName();

            UploadProfileImageCommand command = new(
                UserId: parsedUserId,
                FileName: fileName);

            var result = await sender.Send(command);

            return result.ToActionResult();
        })
            .RequireAuthorization()
            .WithDisplayName(nameof(UploadProfileImage))
            .WithTags(Tags.Users);
    }
}
