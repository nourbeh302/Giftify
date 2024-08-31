using Domain.Users;

namespace Application.Common.Authentication;

public interface IJwtProvider
{
    string Generate(User user);
}
