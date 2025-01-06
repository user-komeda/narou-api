namespace NarouBackend.Application.StockItems.UseCase;

using Microsoft.AspNetCore.Mvc;
using Request;
using Response;
using Domain;
using Domain.StockItems.Service;
using util;


public sealed class StockItemsCreateUseCase(
    IStockItemsService stockItemsService,
    IFindAuthUserRepository findAuthUserRepository)
    : IBaseUseCase<StockItemsInput, StockItemsOutput> {

    public async Task<StockItemsOutput>
        Invoke(string userId, StockItemsInput paramsType) {
        var applicationUser = await findAuthUserRepository.Find(userId);
        var createdData = await stockItemsService.Create(applicationUser, paramsType.Convert());
        return StockItemsOutput.Convert(createdData);
    }
    public Task<ActionResult<StockItemsOutput>> Invoke(StockItemsInput paramsType) =>
        throw new NotImplementedException();
}
