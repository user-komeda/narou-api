namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Application.Monthly;

using Domain;
using Util;


public sealed class MonthlyRankingUseCase(IRankingService rankingService) : IBaseUseCase<RankingInput, List<RankingOutPut>> {
    public async Task<List<RankingOutPut>> Invoke(RankingInput param) {
        var result = await rankingService.GetRanking(param.ConvertMonthlyQuery());
        return RankingOutPut.Convert(result);
    }
}
