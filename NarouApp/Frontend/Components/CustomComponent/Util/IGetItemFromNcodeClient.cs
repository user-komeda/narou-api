namespace NarouApp.Frontend.Components.CustomComponent.Util;

using System.Collections.Specialized;
using Ranking.Infrastructure;


public interface IGetItemFromNcodeClient {
    Task<List<RankingEntity>> Invoke(
        List<RankingEntity> rankingList,
        NameValueCollection queryParamList);
}
