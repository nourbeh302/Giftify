using Domain.Orders;

namespace Infrastructure.Payment;

// 3rd step
public interface IPaymentKeyProvider
{
    Task<string> GetAsync(PaymentOrderId orderId, PaymentAuthToken token, Order order);
}
