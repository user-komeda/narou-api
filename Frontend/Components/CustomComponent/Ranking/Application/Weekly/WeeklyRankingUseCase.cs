namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Application.Weekly;

using Domain;


public sealed class WeeklyRankingUseCase(IRankingService rankingService) : BaseUseCase<RankingInput, List<RankingOutPut>> {
    override internal async Task<List<RankingOutPut>> Invoke(RankingInput param) {
        var result = await rankingService.GetDaialyRanking(param.ConvertWeeklyQuery());
        return RankingOutPut.Convert(result);
    }
}
