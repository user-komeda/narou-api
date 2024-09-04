namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Infrastructure;

using System.Text.Json;
using Domain;


public sealed class RankingRepositoryImpl(HttpClient httpClient) : IRankingRepository {

    public async Task<List<RankingDto>> GetRanking(string url) {
        var response = await httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode) return [];
        var responseStream = await response.Content.ReadAsStreamAsync();
        var result = await JsonSerializer.DeserializeAsync<List<RankingEntity>>(responseStream);
        return RankingEntity.Convert(result ?? []);
    }
}
