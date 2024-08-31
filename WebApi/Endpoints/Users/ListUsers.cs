using Application.Common;
using Application.Users;
using Application.Users.ListUsers;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;
using WebApi.Extensions;
using WebApi.Helpers;

namespace WebApi.Endpoints.Users;

public partial class ListUsers : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/users", async (
            ISender sender,
            IFileManager fileManager,
            int? pageSize,
            int? pageIndex) =>
        {
            Result<PagedList<UserResponse>, Error> result = await sender.Send(new ListUsersQuery(pageSize, pageIndex));

            var newResult = result.Match<Result<PagedList<UserResponse>, Error>>(
                success => Transform(success, fileManager),
                failure => failure);

            return newResult.ToActionResult();
        })
            .WithDisplayName(nameof(ListUsers))
            .WithTags(Tags.Users);
    }
}

public partial class ListUsers
{
    private static PagedList<UserResponse> Transform(PagedList<UserResponse> pagedList, IFileManager fileManager)
    {
        IEnumerable<UserResponse> newPagedList = pagedList.Items
            .Select(i =>
            {
                Result<string, Error> profileImageUrlResult = fileManager.Transform(i.ProfileImageUrl);

                return new UserResponse(
                    Id: i.Id,
                    FirstName: i.FirstName,
                    LastName: i.LastName,
                    Email: i.Email,
                    PhoneNumber: i.PhoneNumber,
                    Address: i.Address,
                    Gender: i.Gender,
                    ProfileImageUrl: profileImageUrlResult.Value!);
            });

        return PagedList<UserResponse>.Create(
            list: newPagedList,
            pageSize: pagedList.PageSize,
            pageIndex: pagedList.PageIndex);
    }
}