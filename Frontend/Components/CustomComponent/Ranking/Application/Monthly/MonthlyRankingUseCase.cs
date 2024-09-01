namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Application.Monthly;

using Domain;


public sealed class MonthlyRankingUseCase(IRankingService rankingService) : BaseUseCase<RankingInput, List<RankingOutPut>> {
    override internal async Task<List<RankingOutPut>> Invoke(RankingInput param) {
        var result = await rankingService.GetDaialyRanking(param.ConvertMonthlyQuery());
        return RankingOutPut.Convert(result);
    }
}
