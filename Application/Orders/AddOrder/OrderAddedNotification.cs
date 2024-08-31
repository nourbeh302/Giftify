using Application.Common.Email;
using Application.Common.Payment;
using Domain.Orders;
using Domain.Users;
using MediatR;

namespace Application.Orders.AddOrder;

public record OrderAddedNotification(Order Order) : INotification;

public class OrderAddedNotificationHandler(
    IEmailSender emailSender,
    IPaymentProvider paymentProvider) : INotificationHandler<OrderAddedNotification>
{
    private readonly IEmailSender _emailSender = emailSender;
    private readonly IPaymentProvider _paymentProvider = paymentProvider;

    public async Task Handle(OrderAddedNotification notification, CancellationToken cancellationToken)
    {
        await SendEmailAsync(notification);

        // payment goes here
        string paymentKey = await _paymentProvider.CreateAsync(notification.Order);
    }

    private async Task SendEmailAsync(OrderAddedNotification notification)
    {
        string userFullName = $"{notification.Order.User.FirstName} {notification.Order.User.LastName}";

        await _emailSender.SendAsync(
            notification.Order.User.Email,
            "Order Confirmation",
            $@"
            <html>
            <head>
                <link rel='preconnect' href='https://fonts.googleapis.com'>
                <link rel='preconnect' href='https://fonts.gstatic.com' crossorigin>
                <link href='https://fonts.googleapis.com/css2?family=Open+Sans:ital,wght@0,300..800;1,300..800&display=swap' rel='stylesheet'>
            </head>
            <body style='font-family: Open Sans, Arial, sans-serif;'>
                <h2 style='color: #333;'>Order Confirmation</h2>
                <p>Dear <strong>{userFullName}</strong>,</p>
                <p>Thank you for your order! Your gift(s) have been successfully placed and are currently being processed.</p>
                <p>The status of your order is currently <strong>pending</strong>, and you will receive a notification once it has been confirmed.</p>
                <p><strong>New Billing Address:</strong><br/>
                   {notification.Order.BillingAddress.FormatAddress()}</p>
                <p><strong>New Shipping Address:</strong><br/>
                   {notification.Order.ShippingAddress.FormatAddress()}</p>
                <p>We appreciate your patience and will keep you updated on the progress of your order.</p>
                <p>Best regards,<br/>The Giftify Team</p>
            </body>
            </html>");
    }
}
