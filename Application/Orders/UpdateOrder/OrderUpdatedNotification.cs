using Application.Common.Email;
using Domain.Orders;
using Domain.Users;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Orders.UpdateOrder;

public record OrderUpdatedNotification(Order Order) : INotification;

public class OrderUpdatedNotificationHandler(
    IEmailSender emailSender,
    IMemoryCache memoryCache) : INotificationHandler<OrderUpdatedNotification>
{
    private readonly IEmailSender _emailSender = emailSender;
    private readonly IMemoryCache _memoryCache = memoryCache;

    public async Task Handle(OrderUpdatedNotification notification, CancellationToken cancellationToken)
    {
        string userFullName = $"{notification.Order.User.FirstName}   {notification.Order.User.LastName}";

        await _emailSender.SendAsync(
            notification.Order.User.Email,
            "Order Update",
            $@"
            <html>
            <head>
                <link rel='preconnect' href='https://fonts.googleapis.com'>
                <link rel='preconnect' href='https://fonts.gstatic.com' crossorigin>
                <link href='https://fonts.googleapis.com/css2?family=Open+Sans:ital,wght@0,300..800;1,300..800&display=swap' rel='stylesheet'>
            </head>
            <body style='font-family: Open Sans, Arial, sans-serif;'>
                <h2 style='color: #333;'>Order Update</h2>
                <p>Dear <strong>{userFullName}</strong>,</p>
                <p>We are pleased to inform you that your order is being processed. Your gift(s) are on their way!</p>
                <p>The status of your order is currently <strong>{Enum.GetName(notification.Order.OrderStatus)!.ToLower()}</strong>. You will receive further notifications as your order progresses.</p>
                <p><strong>New Billing Address:</strong><br/>
                   {notification.Order.BillingAddress.FormatAddress()}</p>
                <p><strong>New Shipping Address:</strong><br/>
                   {notification.Order.ShippingAddress.FormatAddress()}</p>
                <p>Thank you for choosing Giftify. We appreciate your trust in us and will continue to keep you updated.</p>
                <p>Best regards,<br/>The Giftify Team</p>
            </body>
            </html>");
    }
}