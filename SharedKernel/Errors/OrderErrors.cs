using System.Net;

namespace SharedKernel.Errors;

public static class OrderErrors
{
    public static readonly Error OrderNotFound = new("Orders.NotFound", (int)HttpStatusCode.NotFound, "Order is not found");
    public static readonly Error InvalidCredentials = new("Orders.InvalidCredentials", (int)HttpStatusCode.Unauthorized, "The credentials provided are invalid");
    public static readonly Error InvalidEntry = new("Orders.InvalidEntry", (int)HttpStatusCode.BadRequest, "The entry provided are invalid");
    public static readonly Error OrderAlreadyExists = new("Orders.AlreadyExists", (int)HttpStatusCode.Conflict, "A order with this id already exists");
    
    // Additional error codes based on the order statuses
    public static readonly Error OrderPending = new("Orders.Pending", (int)HttpStatusCode.BadRequest, "The order is currently pending");
    public static readonly Error OrderDelivered = new("Orders.Delivered", (int)HttpStatusCode.BadRequest, "The order has already been delivered");
    public static readonly Error OrderCancelled = new("Orders.Cancelled", (int)HttpStatusCode.BadRequest, "The order has already been cancelled");
    public static readonly Error OrderShipped = new("Orders.Shipped", (int)HttpStatusCode.BadRequest, "The order has already been shipped");
    public static readonly Error OrderProcessing = new("Orders.Processing", (int)HttpStatusCode.BadRequest, "The order is currently being processed");
    public static readonly Error OrderReturned = new("Orders.Returned", (int)HttpStatusCode.BadRequest, "The order has already been returned");
    public static readonly Error OrderRefunded = new("Orders.Refunded", (int)HttpStatusCode.BadRequest, "The order has already been refunded");
    public static readonly Error OrderAwaitingPayment = new("Orders.AwaitingPayment", (int)HttpStatusCode.BadRequest, "The order is awaiting payment");
    public static readonly Error OrderOutForDelivery = new("Orders.OutForDelivery", (int)HttpStatusCode.BadRequest, "The order is currently out for delivery");
}