namespace NarouApp.Frontend.Components.CustomComponent.Util;

public interface IBaseUseCase<in TParamsType, TResultType> {

    Task<TResultType> Invoke(TParamsType paramsType);
}
