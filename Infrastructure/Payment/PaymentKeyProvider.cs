using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Configuration;
using Domain.Orders;

namespace Infrastructure.Payment;

public class PaymentKeyProvider(HttpClient httpClient) : IPaymentKeyProvider
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<string> GetAsync(PaymentOrderId orderId, PaymentAuthToken token, Order order)
    {
        string url = "https://accept.paymob.com/api/acceptance/payment_keys";

        var data = new
        {
            auth_token = token.Value,
            amount_cents = "100",
            expiration = 3600,
            order_id = orderId.Value,
            billing_data = new
            {
                apartment = order.BillingAddress.Apartment,
                email = order.User.Email,
                floor = order.BillingAddress.Floor,
                first_name = order.User.FirstName,
                street = order.BillingAddress.Street,
                building = order.BillingAddress.Building,
                phone_number = order.User.PhoneNumber,
                shipping_method = "PKG",
                postal_code = order.BillingAddress.PostalCode,
                city = order.BillingAddress.City,
                country = order.BillingAddress.Country,
                last_name = order.User.LastName,
                state = order.BillingAddress.Governate
            },
            currency = "EGP",
            integration_id = 4721810
        };

        string json = JsonSerializer.Serialize(data);

        using var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

        using var response = await _httpClient.PostAsync(url, httpContent);

        response.EnsureSuccessStatusCode();

        string responseContent = await response.Content.ReadAsStringAsync();
        var responseObject = JsonSerializer.Deserialize<JsonElement>(responseContent);

        string? paymentToken = responseObject.GetProperty("token").GetString();

        return paymentToken!;
    }
}