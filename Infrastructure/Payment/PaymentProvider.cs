using Application.Common.Payment;
using Domain.Orders;

namespace Infrastructure.Payment;

internal sealed class PaymentProvider(
    IPaymentAuthTokenProvider authTokenProvider,
    IPaymentOrderManager orderManager,
    IPaymentKeyProvider paymentKeyProvider) : 
    IPaymentProvider
{
    private readonly IPaymentAuthTokenProvider _authTokenProvider = authTokenProvider;
    private readonly IPaymentOrderManager _orderManager = orderManager;
    private readonly IPaymentKeyProvider _paymentKeyProvider = paymentKeyProvider;

    public async Task<string> CreateAsync(Order order)
    {
        PaymentAuthToken paymentAuthToken = await _authTokenProvider.GetAsync();
        PaymentOrderId orderId = await _orderManager.CreateAsync(paymentAuthToken, order);

        string paymentKey = await _paymentKeyProvider.GetAsync(orderId, paymentAuthToken, order);

        return paymentKey;
    }
}
