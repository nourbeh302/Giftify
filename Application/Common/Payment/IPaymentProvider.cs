using Domain.Orders;

namespace Application.Common.Payment;

public interface IPaymentProvider
{
    Task<string> CreateAsync(Order order);
}