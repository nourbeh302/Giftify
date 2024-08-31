using Domain.Users;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;

namespace Application.Users.GetUserById;

public record GetUserByIdQuery(Guid Id) : 
    IRequest<Result<UserResponse, Error>>;

public class GetUserByIdQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByIdQuery, Result<UserResponse, Error>>
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<Result<UserResponse, Error>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user is null)
        {
            return UserErrors.UserNotFound;
        }

        return new UserResponse(
            Id: user.Id,
            FirstName: user.FirstName,
            LastName: user.LastName,
            Email: user.Email,
            PhoneNumber: user.PhoneNumber,
            Address: user.Address,
            Gender: Enum.GetName(user.Gender)!,
            ProfileImageUrl: user.ProfileImageUrl);
    }
}