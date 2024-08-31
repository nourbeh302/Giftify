using Application.Common.Authentication;
using Domain.Users;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using SharedKernel;
using SharedKernel.Errors;

namespace Application.Users.VerifyUser;

public record VerifyUserCommand(string Email, string Pin) :
    IRequest<Result<Token, Error>>;

public class VerifyUserCommandHandler(
    IUserRepository userRepository,
    IMemoryCache memoryCache,
    IJwtProvider jwtProvider) :
    IRequestHandler<VerifyUserCommand, Result<Token, Error>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMemoryCache _memoryCache = memoryCache;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public async Task<Result<Token, Error>> Handle(VerifyUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (user is null)
        {
            return UserErrors.UserNotFound;
        }

        if (user.IsVerified)
        {
            return UserErrors.AlreadyVerified;
        }

        string key = $"pin-{user.Email}";

        _memoryCache.TryGetValue(key, out object? value);

        if (value is null)
        {
            return UserErrors.PinNotFound;
        }

        if (request.Pin != (string)value)
        {
            return UserErrors.InvalidEntry;
        }

        user = new(
            id: user.Id,
            firstName: user.FirstName,
            lastName: user.LastName,
            email: user.Email,
            passwordHash: user.PasswordHash,
            phoneNumber: user.PhoneNumber,
            gender: user.Gender,
            createdAtUtc: user.CreatedAtUtc,
            modifiedOnUtc: DateTime.UtcNow,
            isVerified: true,
            isLocked: user.IsLocked,
            address: user.Address,
            profileImageUrl: user.ProfileImageUrl);

        await _userRepository.UpdateAsync(user, cancellationToken);

        string tokenValue = _jwtProvider.Generate(user);

        return new Token(tokenValue);
    }
}