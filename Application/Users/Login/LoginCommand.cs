using Application.Common.Authentication;
using Domain.Users;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;

namespace Application.Users.Login;

public record LoginCommand(
    string Email,
    string Password) : 
    IRequest<Result<Token, Error>>;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<Token, Error>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;

    public LoginCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }

    public async Task<Result<Token, Error>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (user is null)
        {
            return UserErrors.UserNotFound;
        }

        bool isPasswordCorrect = _passwordHasher.Verify(request.Password, user.PasswordHash);

        if (!isPasswordCorrect)
        {
            return UserErrors.InvalidCredentials;
        }

        if (!user.IsVerified)
        {
            return UserErrors.EmailNotVerified;
        }

        string tokenValue = _jwtProvider.Generate(user);

        return new Token(tokenValue);
    }

}