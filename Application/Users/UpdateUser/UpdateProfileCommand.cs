using Application.Common.Authentication;
using Domain.Users;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;

namespace Application.Users.UpdateUser;

public record UpdateProfileCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    Gender Gender,
    string Address) :
    IRequest<Result<Token, Error>>;

public class UpdateProfileCommandHandler(
    IUserRepository userRepository,
    IJwtProvider jwtProvider) : IRequestHandler<UpdateProfileCommand, Result<Token, Error>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public async Task<Result<Token, Error>> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user is null)
        {
            return UserErrors.UserNotFound;
        }

        user = new(
            id: user.Id,
            firstName: request.FirstName,
            lastName: request.LastName,
            email: request.Email,
            passwordHash: user.PasswordHash,
            phoneNumber: request.PhoneNumber,
            gender: request.Gender,
            createdAtUtc: user.CreatedAtUtc,
            modifiedOnUtc: DateTime.UtcNow,
            isVerified: user.IsVerified,
            isLocked: user.IsLocked,
            address: request.Address,
            profileImageUrl: user.ProfileImageUrl);

        User updatedUser = await _userRepository.UpdateAsync(user, cancellationToken);

        string tokenValue = _jwtProvider.Generate(updatedUser);

        return new Token(tokenValue);
    }
}
