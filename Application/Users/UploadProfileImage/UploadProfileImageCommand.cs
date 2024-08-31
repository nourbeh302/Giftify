using Domain.Users;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;

namespace Application.Users.UploadProfileImage;

public record UploadProfileImageCommand(
    Guid UserId,
    string FileName) :
    IRequest<Result<UserResponse, Error>>;

public class UploadProfileImageCommandHandler(IUserRepository userRepository) : 
    IRequestHandler<UploadProfileImageCommand, Result<UserResponse, Error>>
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<Result<UserResponse, Error>> Handle(UploadProfileImageCommand request, CancellationToken cancellationToken)
    {
        User? oldUser = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (oldUser is null)
        {
            return UserErrors.UserNotFound;
        }

        oldUser = new(
            id: oldUser.Id,
            oldUser.FirstName,
            oldUser.LastName,
            oldUser.Email,
            oldUser.PasswordHash,
            oldUser.PhoneNumber,
            oldUser.Gender,
            oldUser.CreatedAtUtc,
            DateTime.UtcNow,
            oldUser.IsVerified,
            oldUser.IsVerified,
            oldUser.Address,
            request.FileName);

        User user = await _userRepository.UpdateAsync(oldUser, cancellationToken);

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
