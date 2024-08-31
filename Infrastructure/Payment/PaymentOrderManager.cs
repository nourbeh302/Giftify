using System.Text.Json;
using System.Text;
using System.Collections;
using Domain.Orders;

namespace Infrastructure.Payment;

public class PaymentOrderManager(HttpClient httpClient) : 
    IPaymentOrderManager
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<PaymentOrderId> CreateAsync(PaymentAuthToken token, Order order)
    {
        string url = "https://accept.paymob.com/api/ecommerce/orders";

        var data = new
        {
            auth_token = token.Value,
            delivery_needed = $"{false}",
            amount_cents = "100",
            currency = "EGP",
            items = new ArrayList()
        };

        string json = JsonSerializer.Serialize(data);

        using HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

        using HttpResponseMessage response = await _httpClient.PostAsync(url, httpContent);

        response.EnsureSuccessStatusCode();

        string responseContent = await response.Content.ReadAsStringAsync();
        JsonElement responseObject = JsonSerializer.Deserialize<JsonElement>(responseContent);


        int orderIdValue = responseObject.GetProperty("id").GetInt32();

        return new PaymentOrderId(orderIdValue);
    }
}