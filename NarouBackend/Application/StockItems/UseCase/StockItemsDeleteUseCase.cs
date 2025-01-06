namespace NarouBackend.Application.StockItems.UseCase;

using Microsoft.AspNetCore.Mvc;
using util;


public class StockItemsDeleteUseCase : IBaseUseCase<string, IActionResult> {

    public Task<IActionResult> Invoke(string userId, string paramsType) =>
        throw new NotImplementedException();
}
