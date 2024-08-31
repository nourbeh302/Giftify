using System.Net;

namespace SharedKernel.Errors;

public static class GiftErrors
{
    public static readonly Error GiftNotFound = new("Gifts.NotFound", (int)HttpStatusCode.NotFound, "Gift is not found");
    public static readonly Error InvalidEntry = new("Gifts.InvalidEntry", (int)HttpStatusCode.BadRequest, "The entry provided are invalid");
}
