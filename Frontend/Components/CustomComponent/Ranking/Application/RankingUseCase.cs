namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Application;

using Domain;


public sealed class RankingUseCase<TParamsType, TResultType>(IRankingService rankingService) : BaseUseCase<RankingInput, List<RankingOutPut>> {
    public override async Task<List<RankingOutPut>> Invoke(RankingInput param) {
        var result = await rankingService.GetDaialyRanking(param.ConvertQuery());
        return RankingOutPut.Convert(result);
    }
}
