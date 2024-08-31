using Domain.Users;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;

namespace Application.Users.DeleteUser;

public record DeleteUserCommand(Guid Id) : 
    IRequest<Result<int, Error>>;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result<int, Error>>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<int, Error>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user is null)
        {
            return UserErrors.UserNotFound;
        }

        await _userRepository.DeleteAsync(request.Id, cancellationToken);

        return 1;
    }
}
