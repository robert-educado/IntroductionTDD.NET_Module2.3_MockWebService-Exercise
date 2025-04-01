using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using BancoLibre.Application.Services;

namespace BancoLibre.UnitTests.Services;

public class CreditScoreProvider : ICreditScoreProvider
{
    private readonly HttpClient httpClient;

    public CreditScoreProvider(string url)
    {
        httpClient = new HttpClient();

        httpClient.BaseAddress = new Uri(url);

        httpClient.DefaultRequestHeaders.Accept.Add(
          new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<int> GetCreditScoreAsync(string socialSecurityNumber)
    {
        var response = await httpClient
           .GetAsync($"/api/creditscore/{socialSecurityNumber}");

        response.EnsureSuccessStatusCode();

        // Read the response content 
        string jsonResponse = await response
          .Content
          .ReadAsStringAsync();

        // Assuming the API returns a JSON object with a "score"
        // property.
        var result = JsonSerializer
          .Deserialize<GetCreditScoreResponse>(jsonResponse);

        return result.Score;
    }

    public record GetCreditScoreResponse(int Score, string Description);

}
