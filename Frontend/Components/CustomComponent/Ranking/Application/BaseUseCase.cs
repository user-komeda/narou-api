namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Application;

public abstract class BaseUseCase<TParamsType, TResultType> {

    public abstract Task<List<RankingOutPut>> Invoke(TParamsType paramsType);
}
