using System.Net;

namespace SharedKernel.Errors;

public static class LikedGiftErrors
{
    public static readonly Error LikedGiftNotFound = new("LikedGifts.NotFound", (int)HttpStatusCode.NotFound, "LikedGift is not found");
    public static readonly Error InvalidEntry = new("LikedGifts.InvalidEntry", (int)HttpStatusCode.BadRequest, "The entry provided are invalid");
}
