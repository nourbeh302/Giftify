using Application.Common.Authentication;
using Application.Common.Email;
using Domain.Users;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using SharedKernel;
using SharedKernel.Errors;

namespace Application.Users.GetSingleUsePin;

public record GetInstantPinCommand(string Email) :
    IRequest<Result<int, Error>>;

public class GetInstantPinCommandHandler :
    IRequestHandler<GetInstantPinCommand, Result<int, Error>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPinGenerator _pinGenerator;
    private readonly IMemoryCache _memoryCache;
    private readonly IEmailSender _emailSender;

    public GetInstantPinCommandHandler(
        IUserRepository userRepository,
        IPinGenerator pinGenerator,
        IMemoryCache memoryCache,
        IEmailSender emailSender)
    {
        _userRepository = userRepository;
        _pinGenerator = pinGenerator;
        _memoryCache = memoryCache;
        _emailSender = emailSender;
    }

    public async Task<Result<int, Error>> Handle(GetInstantPinCommand request, CancellationToken cancellationToken)
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

        string pin = _pinGenerator.Generate();

        _memoryCache.TryGetValue(key, out string? value);

        if (value is not null)
        {
            _memoryCache.Remove(key);
        }

        int minutes = 2;

        await _memoryCache.GetOrCreateAsync(
            key,
            entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(minutes));

                return Task.FromResult<string?>(pin);
            });

        await _emailSender.SendAsync(request.Email, "Account Confirmation", $"""
            <p>Here is the instant pin: {pin}</p>
            <p>This pin is destroyed automatically after {minutes} minutes of generation</p>
            """);

        return 1;
    }
}