using Application.Common;
using Domain.Users;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;

namespace Application.Users.ListUsers;

public record ListUsersQuery(int? PageSize, int? PageIndex) : 
    IRequest<Result<PagedList<UserResponse>, Error>>;

public class ListUsersQueryHandler(IUserRepository userRepository) : IRequestHandler<ListUsersQuery, Result<PagedList<UserResponse>, Error>>
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<Result<PagedList<UserResponse>, Error>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
    {
        int pageSize = request.PageSize ?? 4;
        int pageIndex = request.PageIndex ?? 1;

        var users = await _userRepository.ListAsync(cancellationToken);

        var userResponses = users
            .Select(u => new UserResponse(
                Id: u.Id,
                FirstName: u.FirstName,
                LastName: u.LastName,
                Email: u.Email,
                PhoneNumber: u.PhoneNumber,
                Address: u.Address,
                Gender: Enum.GetName(u.Gender)!,
                ProfileImageUrl: u.ProfileImageUrl));

        var pagedList = PagedList<UserResponse>.Create(
            list: userResponses,
            pageSize: pageSize,
            pageIndex: pageIndex);

        return pagedList;
            
    }
}