using Domain.Orders;

namespace Infrastructure.Payment;

// 2nd step
public interface IPaymentOrderManager
{
    Task<PaymentOrderId> CreateAsync(PaymentAuthToken token, Order order);
}
