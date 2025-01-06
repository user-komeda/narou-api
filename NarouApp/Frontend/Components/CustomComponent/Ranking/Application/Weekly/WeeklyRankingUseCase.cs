namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Application.Weekly;

using Domain;
using Util;


public sealed class WeeklyRankingUseCase(IRankingService rankingService) : IBaseUseCase<RankingInput, List<RankingOutPut>> {
    public async Task<List<RankingOutPut>> Invoke(RankingInput param) {
        var result = await rankingService.GetRanking(param.ConvertWeeklyQuery());
        return RankingOutPut.Convert(result);
    }
}
