using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Payment;

public class PaymentAuthTokenProvider(
    HttpClient httpClient,
    IConfiguration configuration) : 
    IPaymentAuthTokenProvider
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly IConfiguration _configuration = configuration;

    public async Task<PaymentAuthToken> GetAsync()
    {
        string apiKey = _configuration["Paymob:ApiKey"] ?? 
            throw new InvalidOperationException("API Key not found in configuration");

        string url = "https://accept.paymob.com/api/auth/tokens";

        var data = new { api_key = apiKey };

        string json = JsonSerializer.Serialize(data);

        using HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

        using HttpResponseMessage response = await _httpClient.PostAsync(url, httpContent);

        response.EnsureSuccessStatusCode();

        string responseContent = await response.Content.ReadAsStringAsync();
        JsonElement responseObject = JsonSerializer.Deserialize<JsonElement>(responseContent);

        string? tokenValue = responseObject.GetProperty("token").GetString();

        return new PaymentAuthToken(tokenValue!);
    }
}