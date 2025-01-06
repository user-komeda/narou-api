namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Application.Quarterly;

using Domain;
using Util;


public sealed class QuarterlyRankingUseCase(IRankingService rankingService) : IBaseUseCase<RankingInput, List<RankingOutPut>> {
    public async Task<List<RankingOutPut>> Invoke(RankingInput param) {
        var result = await rankingService.GetRanking(param.ConvertQuarterlyQuery());
        return RankingOutPut.Convert(result);
    }
}
