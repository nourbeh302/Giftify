using System.Net;

namespace SharedKernel.Errors;

public static class UserErrors
{
    public static readonly Error UserNotFound = new("Users.NotFound", (int)HttpStatusCode.NotFound, "User is not found");
    public static readonly Error InvalidCredentials = new("Users.InvalidCredentials", (int)HttpStatusCode.Unauthorized, "The credentials provided are invalid");
    public static readonly Error InvalidEntry = new("Users.InvalidEntry", (int)HttpStatusCode.BadRequest, "The entry provided are invalid");
    public static readonly Error UserAlreadyExists = new("Users.AlreadyExists", (int)HttpStatusCode.Conflict, "A user with this email already exists");
    public static readonly Error UserNotAuthorized = new("Users.NotAuthorized", (int)HttpStatusCode.Unauthorized, "User is not authorized to perform this action");
    public static readonly Error UserLockedOut = new("Users.LockedOut", (int)HttpStatusCode.Locked, "User account is locked out");
    public static readonly Error PasswordExpired = new("Users.PasswordExpired", (int)HttpStatusCode.Forbidden, "User's password has expired");
    public static readonly Error PasswordTooWeak = new("Users.PasswordTooWeak", (int)HttpStatusCode.BadRequest, "The provided password does not meet security requirements");
    public static readonly Error EmailNotVerified = new("Users.EmailNotVerified", (int)HttpStatusCode.Forbidden, "User's email address has not been verified");
    public static readonly Error AlreadyVerified = new("Users.AlreadyVerified", (int)HttpStatusCode.BadRequest, "User's email address has already been verified");
    public static readonly Error PinNotFound = new("Users.PinNotFound", (int)HttpStatusCode.NotFound, "Pin is not found");
}
