using Application.Common.Authentication;
using Application.Common.Email;
using Domain.Users;
using FluentValidation.Results;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;

namespace Application.Users.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string PasswordHash,
    string PhoneNumber,
    Gender Gender,
    string Address) :
    IRequest<Result<UserResponse, Error>>;

public class RegisterCommandHandler(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher) : 
    IRequestHandler<RegisterCommand, Result<UserResponse, Error>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;

    public async Task<Result<UserResponse, Error>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        User? oldUserByEmail = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (oldUserByEmail is not null)
        {
            return UserErrors.UserAlreadyExists;
        }

        RegisterCommandValidator validator = new();

        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return UserErrors.InvalidEntry;
        }

        string hashedPassword = _passwordHasher.Hash(request.PasswordHash);

        User newUser = new(
            id: Guid.NewGuid(),
            firstName: request.FirstName,
            lastName: request.LastName,
            email: request.Email,
            passwordHash: hashedPassword,
            phoneNumber: request.PhoneNumber,
            gender: request.Gender,
            createdAtUtc: DateTime.UtcNow,
            modifiedOnUtc: DateTime.UtcNow,
            address: request.Address,
            isVerified: false,
            isLocked: false,
            profileImageUrl: "default.png");

        User user = await _userRepository.AddAsync(newUser, cancellationToken);

        return new UserResponse(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            user.PhoneNumber,
            user.Address,
            Enum.GetName(user.Gender)!,
            ProfileImageUrl: user.ProfileImageUrl);
    }
}
