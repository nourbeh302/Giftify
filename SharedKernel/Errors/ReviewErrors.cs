using System.Net;

namespace SharedKernel.Errors;

public static class ReviewErrors
{
    public static readonly Error ReviewNotFound = new("Reviews.NotFound", (int)HttpStatusCode.NotFound, "Review is not found");
    public static readonly Error ReviewAlreadyExists = new("Reviews.AlreadyExists", (int)HttpStatusCode.Conflict, "A review with this id already exists");
}
