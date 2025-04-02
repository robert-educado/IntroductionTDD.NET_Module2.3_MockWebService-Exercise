using System.Net.Http.Headers;
using System.Text.Json;
using BancoLibre.Application.Interfaces;

namespace BancoLibre.Infrastructure.Providers;

public class CreditScoreProvider : ICreditScoreProvider
{
    private readonly HttpClient httpClient;

    public CreditScoreProvider()
    {
        httpClient = new HttpClient();

        httpClient.BaseAddress = new Uri("https://localhost:8000");

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
          .Deserialize<GetCreditScoreResponse>(jsonResponse, new JsonSerializerOptions
          {
              PropertyNameCaseInsensitive = true
          });

        return result.Score;
    }

    public record GetCreditScoreResponse(int Score, string Description);

    //public class GetCreditScoreResponse
    //{
    //    public int Score { get; set; }
    //    public String Description { get; set; }
    //}

}
