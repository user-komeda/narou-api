namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Application.Daily;

using Domain;


public sealed class DailyRankingUseCase(IRankingService rankingService) : BaseUseCase<RankingInput, List<RankingOutPut>> {
    override internal async Task<List<RankingOutPut>> Invoke(RankingInput param) {
        var result = await rankingService.GetDaialyRanking(param.ConvertDailyQuery());
        return RankingOutPut.Convert(result);
    }
}
