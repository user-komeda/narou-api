namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Application.Quarterly;

using Domain;


public sealed class QuarterlyRankingUseCase(IRankingService rankingService) : BaseUseCase<RankingInput, List<RankingOutPut>> {
    override internal async Task<List<RankingOutPut>> Invoke(RankingInput param) {
        var result = await rankingService.GetDaialyRanking(param.ConvertQuarterlyQuery());
        return RankingOutPut.Convert(result);
    }
}
