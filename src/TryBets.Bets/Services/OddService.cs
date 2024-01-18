using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace TryBets.Bets.Services;

public class OddService : IOddService
{
    private readonly HttpClient _client;
    public OddService(HttpClient client)
    {
        _client = client;
    }

    public async Task<object> UpdateOdd(int MatchId, int TeamId, decimal BetValue)
    {
        var request = await _client.PatchAsync($"http://localhost:5504/odds/{MatchId}/{TeamId}/{BetValue}", new StringContent(JsonSerializer.Serialize(new {}), System.Text.Encoding.UTF8, "application/json"));
        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "aspnet-user-agent");

        if (!request.IsSuccessStatusCode)
        {
            return default(object);
        }

        var result = await request.Content.ReadFromJsonAsync<List<object>>();

        return result;
    }
}