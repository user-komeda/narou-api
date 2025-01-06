namespace NarouApp.Frontend.Components.CustomComponent.Util;

using System.Collections.Specialized;
using System.Text.Json;
using Ranking.Infrastructure;


public class GetItemFromNcodeClientInvoker {
    static string BuildUrl(List<RankingEntity> rankingList,
        NameValueCollection queryParamList) {
        if (queryParamList.Count != 4){
            throw new Exception();
        }
        var ncodeList = rankingList.Select(static ranking => ranking.Ncode).ToList();
        var queryParameter = string.Join("-", ncodeList);
        var param = QueryParamListToString(queryParamList);
        return $"https://api.syosetu.com/novelapi/api/?ncode={queryParameter}&{param}";
    }

    static string QueryParamListToString(NameValueCollection queryParamList) {
        var tmp = queryParamList.AllKeys.Skip(1)
            .Select(key => $"{key}={queryParamList[key]}").ToList();
        return string.Join("&", tmp);
    }

    public async static Task<List<RankingEntity>> GetItemFromNcode(HttpClient httpClient,
        List<RankingEntity> rankingList,
        NameValueCollection queryParamList) {
        var response = await httpClient.GetAsync(BuildUrl(rankingList, queryParamList));
        if (!response.IsSuccessStatusCode) return [];

        var responseStream = await response.Content.ReadAsStreamAsync();
        var result = await JsonSerializer.DeserializeAsync<List<RankingEntity>>(responseStream);
        return result ?? [];
    }
}
