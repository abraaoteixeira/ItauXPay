using System.Net.Http.Json;
using ItauXPay.Models;

namespace ItauXPay.Services;

public class ItauPaymentService
{
    private readonly HttpClient _httpClient;

    public ItauPaymentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PaymentResponse> ProcessPaymentAsync(Payment payment)
    {
        // Simulação: substituir pelo endpoint real da API do Itaú
        var response = await _httpClient.PostAsJsonAsync("https://api.itau.com.br/payments", payment);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Failed to process payment via Itaú API.");

        return await response.Content.ReadFromJsonAsync<PaymentResponse>();
    }
}

public class PaymentResponse
{
    public string Status { get; set; }
}