namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Application;

public abstract class BaseUseCase<TParamsType, TResultType> {

    internal abstract Task<TResultType> Invoke(TParamsType paramsType);
}
