namespace Infrastructure.Payment;

// 1st step
public interface IPaymentAuthTokenProvider
{
    Task<PaymentAuthToken> GetAsync();
}
