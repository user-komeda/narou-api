namespace NarouBackend.util;

using Microsoft.AspNetCore.Mvc;


public interface IBaseUseCase<in TParamsType, TResultType> {
    Task<TResultType> Invoke(string userId, TParamsType paramsType);
}
