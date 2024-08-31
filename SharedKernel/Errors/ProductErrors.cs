using System.Net;

namespace SharedKernel.Errors;

public static class ProductErrors
{
    public static readonly Error ProductNotFound = new("Products.NotFound", (int)HttpStatusCode.NotFound, "Product is not found");
    public static readonly Error InvalidEntry = new("Products.InvalidEntry", (int)HttpStatusCode.BadRequest, "The entries provided are invalid");
    public static readonly Error ProductAlreadyExists = new("Products.AlreadyExists", (int)HttpStatusCode.Conflict, "A product with this id already exists");
    public static readonly Error OutOfStock = new("Products.OutOfStock", (int)HttpStatusCode.BadRequest, "The product is out of stock");
}
