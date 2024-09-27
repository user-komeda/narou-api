namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Infrastructure;

using System.Text.Json;
using System.Web;
using Domain;
using Util;


public sealed class RankingRepositoryImpl(HttpClient httpClient, IGetItemFromNcodeClient client)
    : IRankingRepository {

    public async Task<List<RankingDto>> GetRanking(string url) {
        var response = await httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode) return [];

        var responseStream = await response.Content.ReadAsStreamAsync();
        var tmpResult = await JsonSerializer.DeserializeAsync<List<RankingEntity>>(responseStream);

        return RankingEntity.Convert(await client.Invoke(tmpResult ?? [],
        HttpUtility.ParseQueryString(url.Split("?")[1])));
    }
}
