namespace NarouBackend.util;


public interface IBaseUseCase<in TParamsType, TResultType> {
    Task<TResultType> Invoke(string userId, TParamsType paramsType);
}
