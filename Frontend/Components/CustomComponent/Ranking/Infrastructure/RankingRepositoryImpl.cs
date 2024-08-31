namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Infrastructure;

using System.Text.Json;
using Domain;


public sealed class RankingRepository(HttpClient httpClient) : IRankingRepository {

    public async Task<List<RankingDto>> GetDaialyRanking(string url) {
        var response = await httpClient.GetAsync(url);
        Console.WriteLine(response.StatusCode);
        if (!response.IsSuccessStatusCode) return [];

        var responseStream = await response.Content.ReadAsStreamAsync();
        Console.WriteLine(responseStream);
        var result = await JsonSerializer.DeserializeAsync<List<RankingEntity>>(responseStream);
        return RankingEntity.Convert(result ?? []);
    }
}
