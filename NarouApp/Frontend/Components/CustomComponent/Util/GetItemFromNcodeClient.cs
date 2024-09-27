namespace NarouApp.Frontend.Components.CustomComponent.Util;

using System.Collections.Specialized;
using Ranking.Infrastructure;


public class GetItemFromNcodeClient(HttpClient httpClient) : IGetItemFromNcodeClient {

    public Task<List<RankingEntity>> Invoke(
        List<RankingEntity> rankingList,
        NameValueCollection queryParamList) => GetItemFromNcodeClientInvoker.GetItemFromNcode(
    httpClient,
    rankingList,
    queryParamList);
}
