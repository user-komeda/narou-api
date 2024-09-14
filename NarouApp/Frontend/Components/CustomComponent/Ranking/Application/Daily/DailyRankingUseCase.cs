namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Application.Daily;

using Domain;
using Util;


public sealed class DailyRankingUseCase(IRankingService rankingService) : IBaseUseCase<RankingInput, List<RankingOutPut>> {
    public async Task<List<RankingOutPut>> Invoke(RankingInput param) {
        var result = await rankingService.GetRanking(param.ConvertDailyQuery());
        return RankingOutPut.Convert(result);
    }
}
